
namespace KarataClub.Application.Features.Subscriptions.Queries.GetSubscription;

public sealed record GetSubscriptionQuery(Guid SubscriptionId):IRequest<Result<SubscriptionDto>>
{
}
