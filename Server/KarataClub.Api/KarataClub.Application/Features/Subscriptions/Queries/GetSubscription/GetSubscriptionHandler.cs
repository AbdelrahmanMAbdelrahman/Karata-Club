namespace KarataClub.Application.Features.Subscriptions.Queries.GetSubscription;

public sealed class GetSubscriptionHandler (
    IAppDbContext context,ILogger<GetSubscriptionHandler> logger
    ): IRequestHandler<GetSubscriptionQuery, Result<SubscriptionDto>>
{
    public async Task<Result<SubscriptionDto>> Handle(
        GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        Subscription? subscription = await context.Subscriptions
              .Include(s => s.Member)
                .ThenInclude(m => m.Person)
              .FirstOrDefaultAsync(s => s.Id == request.SubscriptionId);

        if(subscription is null)
        {
            logger.LogError("No subscription found for id = {SubscriptionId}",request.SubscriptionId);
            return ApplicationErrors.SubscriptionNotFound(request.SubscriptionId);
        }

        return subscription.ToDto();
    }
}
