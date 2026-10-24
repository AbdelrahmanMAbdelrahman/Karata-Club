namespace KarataClub.Application.Features.BeltTests.Commands.CreateBeltTests;

public sealed class CreateBeltTestHandler(
    IAppDbContext context,ILogger<CreateBeltTestHandler>logger,TimeProvider timeProvider
    ) : IRequestHandler<CreateBeltTestCommand, Result<BeltTestDto>>
{
    public async Task<Result<BeltTestDto>> Handle(CreateBeltTestCommand request, CancellationToken cancellationToken)
    {
        Member? member = await context.Members
            .AsNoTracking()
            .Include(m => m.Person)
            .FirstOrDefaultAsync(m=>m.Id==request.MemberId,cancellationToken);
        if(member is null)
        {
            logger.LogError("No member Found for id = {MemberId}", request.MemberId);
            return ApplicationErrors.MemberNotFound(request.MemberId);
        }

        Instructor? instructor = await context.Instructors
            .AsNoTracking()
            .Include(m => m.Person)
            .FirstOrDefaultAsync(m=>m.Id==request.InstructorId,cancellationToken);
        if(instructor is null)
        {
            logger.LogError("No Instructor Found for id = {InstructorId}", request.InstructorId);
            return ApplicationErrors.InstructorNotFound(request.InstructorId);
        }
        BeltRank? beltRank = await context.BeltRanks
            .AsNoTracking()
            .FirstOrDefaultAsync(m=>m.Id==request.BeltRankId,cancellationToken);
        if(beltRank is null)
        {
            logger.LogError("No belt Rank Found for id = {MemberId}", request.BeltRankId);
            return ApplicationErrors.BeltRankNotFound(request.BeltRankId);
        }
        bool hasSubscription = await context.Subscriptions.AnyAsync(
            s=>s.MemberId==request.MemberId&&
            s.EndDate>DateTimeOffset.UtcNow
            ,cancellationToken);
        if (!hasSubscription)
        {
            logger.LogError("No Subscription found for member id {memberId}",request.MemberId);
            return ApplicationErrors.SubscriptionNotFound(Guid.Empty);
        }
        bool conflict = await context.BeltTests
            .AnyAsync(
            bt => bt.InstructorId == request.InstructorId &&
            bt.MemberId == request.MemberId &&
            bt.BeltRankId == request.BeltRankId&&
            bt.TestDate>DateTime.UtcNow
            );
        if (conflict) {
            logger.LogWarning("Already a belt test holding for this member");
            return ApplicationErrors.BeltTestAlreadyExist;
        }
        Result<Payment> createPaymentResult = Payment.Create(member.Id,timeProvider.GetUtcNow(),
            beltRank.TestFees,request.Notes);
        if (createPaymentResult.IsFailure)
        {
            logger.LogError(string.Join(" - ",createPaymentResult.Errors));
            return createPaymentResult.Errors;
        }
        Payment payment = createPaymentResult.Value;
        DateTimeOffset testDate=timeProvider.GetUtcNow().AddDays(AppSettings.TestPeriodInDays);

        Result<BeltTest> createBeltTestResult = BeltTest.Create(
            testDate,beltRank.Id,
            timeProvider.GetUtcNow(),instructor.Id,member.Id,payment.Id);
        if (createBeltTestResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createBeltTestResult.Errors));
            return createBeltTestResult.Errors;
        }
        BeltTest beltTest = createBeltTestResult.Value;
        beltTest.Payment = payment;
        await context.BeltTests.AddAsync(beltTest,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        beltTest.Member= member;
        beltTest.Instructor= instructor;
        beltTest.BeltRank= beltRank;
        return beltTest.ToDto();
    }
}
