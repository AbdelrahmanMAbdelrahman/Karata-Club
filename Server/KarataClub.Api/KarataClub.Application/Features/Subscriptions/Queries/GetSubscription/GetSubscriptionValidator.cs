namespace KarataClub.Application.Features.Subscriptions.Queries.GetSubscription;

public sealed class GetSubscriptionValidator:AbstractValidator<GetSubscriptionQuery>
{
    public GetSubscriptionValidator()
    {
        RuleFor(s=>s.SubscriptionId).Must(id=>id!=Guid.Empty)
            .WithMessage("Provide a valid '{PropertyName}'");
    }
}
