using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Subscriptions;

namespace KarataClub.Tests.Common.Subscriptions;

public static class SubscriptionFactory
{
    public static Result<Subscription>Create(
        Guid? paymentId=null,
        Guid? memberId = null,
        DateTimeOffset? startDate = null,
        DateTimeOffset? endDate = null, 
        decimal? fees=null)
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        return Subscription.Create(
            paymentId??Guid.NewGuid(),
            memberId??Guid.NewGuid(),
            startDate??fakeTimeProvider.GetUtcNow(),
            endDate??fakeTimeProvider.GetUtcNow().AddDays(30),
            fees??1
            );
    }
}
