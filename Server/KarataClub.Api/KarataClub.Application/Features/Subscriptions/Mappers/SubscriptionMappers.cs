using KarataClub.Application.Features.Subscriptions.Dtos;

namespace KarataClub.Application.Features.Subscriptions.Mappers;

public static class SubscriptionMappers
{
    public static SubscriptionDto ToDto(this Subscription subscription)
    {
        return new SubscriptionDto(subscription.Id,subscription.Fees,subscription.StartDate,
            subscription.EndDate,subscription.Member.ToDto());
    }

    public static IQueryable<SubscriptionDto> ToDto(this IQueryable< Subscription> subscription)
    {
        return subscription.Select(s =>
        new SubscriptionDto(s.Id,s.Fees,s.StartDate,s.EndDate,s.Member.ToDto()));
    }
}
