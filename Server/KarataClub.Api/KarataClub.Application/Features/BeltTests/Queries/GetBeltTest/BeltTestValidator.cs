namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTest;

public sealed class BeltTestValidator:AbstractValidator<BeltTestQuery>
{
    public BeltTestValidator()
    {
        RuleFor(bt=>bt.BeltTestId).Must(id=>id!=Guid.Empty)
            .WithMessage("Provide a valid '{PropertyName}'");
    }
}
