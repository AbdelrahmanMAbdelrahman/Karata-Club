namespace KarataClub.Application.Features.Subscriptions.Commands.CreateSubscriptions;

public class CreateSubscriptionValidator:AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionValidator()
    {
        RuleFor(s=>s.Fees).NotEmpty().Must(s=>s>0&&s<10000).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(s => s.MemberId).NotEmpty().Must(s => s !=Guid.Empty).WithMessage("Provide a valid '{PropertyName}'");
    }
}
