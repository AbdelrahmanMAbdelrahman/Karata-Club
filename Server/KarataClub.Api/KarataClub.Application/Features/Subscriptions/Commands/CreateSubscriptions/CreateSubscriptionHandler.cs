using Microsoft.Extensions.Caching.Hybrid;

namespace KarataClub.Application.Features.Subscriptions.Commands.CreateSubscriptions;

public class CreateSubscriptionHandler(
    IAppDbContext context, HybridCache hybridCache,
    ILogger<CreateSubscriptionHandler> logger,TimeProvider timeProvider
    ) : IRequestHandler<CreateSubscriptionCommand, Result<SubscriptionDto>>
{
    async Task<Result<SubscriptionDto>> IRequestHandler<CreateSubscriptionCommand,
        Result<SubscriptionDto>>.Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var member = await context.Members.
            Include(m=>m.Person)
            .FirstOrDefaultAsync(m => m.Id == request.MemberId && m.Active,cancellationToken);
        if (member is null)
        {
            logger.LogError("No Member found for this id : {memberId}", request.MemberId);
            return ApplicationErrors.MemberNotFound(request.MemberId);
        }
        Result<Payment> createPaymentResult = Payment.Create(request.MemberId,
            timeProvider.GetUtcNow(), request.Fees, request.Notes ?? "");
        if (createPaymentResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createPaymentResult.Errors));
            return createPaymentResult.Errors;
        }

        DateTimeOffset now = timeProvider.GetUtcNow();
        bool subExist = await context.Subscriptions.AnyAsync(s=>s.MemberId==request.MemberId&&
        s.StartDate.Month==now.Month&&
        s.StartDate.Year==now.Year);
        if (subExist) {
            logger.LogError("Subscription already exist for member with id {memberId}", request.MemberId);
            return ApplicationErrors.SubscriptionAlreadyExist;
        }

        DateTimeOffset defaultEndDate = new DateTimeOffset(now.Year, now.Month, 
            DateTime.DaysInMonth(now.Year, now.Month),
           23,59,59,now.Offset);

        Result<Subscription> createSubResult = Subscription.Create(createPaymentResult.Value.Id,
            request.MemberId, now, defaultEndDate, request.Fees);
        if (createSubResult.IsFailure) {
            logger.LogError(string.Join(" - ", createSubResult.Errors));
            return createSubResult.Errors;  
        }

        Subscription subscription=createSubResult.Value;
        subscription.Member = member;
        subscription.Payment = createPaymentResult.Value;
        await context.Subscriptions.AddAsync(subscription,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await hybridCache.RemoveByTagAsync("Subscription");
        return subscription.ToDto();

    }
}
