
namespace KarataClub.Application.Features.Subscriptions.Queries.GetSubscription;

public sealed record GetSubscriptionQuery(Guid SubscriptionId) : ICachedQuery<Result<SubscriptionDto>>
{
    public string CacheKey => $"Subscription:{SubscriptionId}";

    public string[] Tags => ["Subscription"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
