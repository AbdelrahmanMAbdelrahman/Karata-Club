namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTests;

public sealed class BeltTestValidator:AbstractValidator<BeltTestsQuery>
{
    public BeltTestValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
