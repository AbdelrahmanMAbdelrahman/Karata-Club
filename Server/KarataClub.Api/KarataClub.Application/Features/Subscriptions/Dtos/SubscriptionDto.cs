namespace KarataClub.Application.Features.Subscriptions.Dtos;
public sealed record SubscriptionDto(
    Guid Id,decimal Fees,DateTimeOffset StartDate, DateTimeOffset EndDate,MemberDto Member);
