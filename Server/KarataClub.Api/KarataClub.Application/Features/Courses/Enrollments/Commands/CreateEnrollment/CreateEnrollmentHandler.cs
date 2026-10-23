

namespace KarataClub.Application.Features.Courses.Enrollments.Commands.CreateEnrollment;

public sealed class CreateEnrollmentHandler (
    IAppDbContext context,ILogger<CreateEnrollmentHandler>logger,TimeProvider timeProvider
    ): IRequestHandler<EnrollmentCommand, Result<EnrollmentDto>>
{
    public async Task<Result<EnrollmentDto>> Handle(EnrollmentCommand request, CancellationToken cancellationToken)
    {
        Course? course = await context.Courses.FindAsync(request.CourseId);
        if(course is null ||!course.Active)
        {
            logger.LogError("no course found with id = {CourseId}",request.CourseId);
            return ApplicationErrors.CourseNotFound(request.CourseId);
        }
        Member? member = await context.Members
            .Include(m=>m.Person)
            .FirstOrDefaultAsync(m=>m.Id== request.MemberId,cancellationToken);
        if(member is null ||!member.Active)
        {
            logger.LogError("no member found with id = {MemberId}",request.MemberId);
            return ApplicationErrors.MemberNotFound(request.MemberId);
        }

        bool conflict = await context.Enrollments.AnyAsync(e=>e.MemberId==request.MemberId&&
        e.CourseId==request.CourseId,cancellationToken);
        if (conflict) {
            logger.LogError("member already has enrolled in this course");
            return ApplicationErrors.MemberHasAlreadyEnrollment(request.CourseId,request.MemberId);
        }

        bool hasSubscription = await context.Subscriptions.AnyAsync(
            s=>s.MemberId==request.MemberId&&
            s.EndDate>timeProvider.GetUtcNow()
            ,cancellationToken
            );
        if (!hasSubscription)
        {
            logger.LogError("Must has Subscribtion ");
            return ApplicationErrors.MustHasSubscription(request.MemberId);
        }
        Result<Payment> createPaymentResult = Payment.Create(member.Id,timeProvider.GetUtcNow(),
            course.Fees,request.Notes);
        if (createPaymentResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createPaymentResult.Errors));
            return createPaymentResult.Errors;
        }
        Payment payment = createPaymentResult.Value;

        Result<CourseEnrollment> createEnrollResult = CourseEnrollment.Create(course.Id, member.Id,payment.Id);
        if (createEnrollResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createEnrollResult.Errors));
            return createEnrollResult.Errors;
        }
        CourseEnrollment courseEnrollment = createEnrollResult.Value;
        courseEnrollment.Member=member; 
        courseEnrollment.Course=course;
        courseEnrollment.Payment=payment;

        await context.Enrollments.AddAsync(courseEnrollment,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return courseEnrollment.ToDto();


    }
}
