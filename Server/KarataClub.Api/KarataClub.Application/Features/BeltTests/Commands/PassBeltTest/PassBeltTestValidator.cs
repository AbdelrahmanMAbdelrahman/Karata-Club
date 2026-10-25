namespace KarataClub.Application.Features.BeltTests.Commands.PassBeltTest;

public sealed class PassBeltTestValidator:AbstractValidator<PassBeltCommand>
{
    public PassBeltTestValidator()
    {
        RuleFor(b => b.BeltTestId).Must(id => id != Guid.Empty)
            .WithMessage("Provide a valid value for '{PropertyName}'");
    }
}
