namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltRankBeltTests;

public sealed class MemberBeltTestValidator:AbstractValidator<BeltRankBeltTestsQuery>
{
    public MemberBeltTestValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(i => i.BeltRankId).Must(id=>id!=Guid.Empty).WithMessage("Provide a valid '{PropertyName}'");
    }
}
