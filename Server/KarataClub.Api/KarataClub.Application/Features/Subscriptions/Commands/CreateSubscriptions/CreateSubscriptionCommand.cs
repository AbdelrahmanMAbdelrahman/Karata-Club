using KarataClub.Application.Features.Subscriptions.Dtos;

namespace KarataClub.Application.Features.Subscriptions.Commands.CreateSubscriptions;

public sealed record CreateSubscriptionCommand(
    Guid MemberId,  decimal Fees, string? Notes) 
    : IRequest<Result<SubscriptionDto>>;

 