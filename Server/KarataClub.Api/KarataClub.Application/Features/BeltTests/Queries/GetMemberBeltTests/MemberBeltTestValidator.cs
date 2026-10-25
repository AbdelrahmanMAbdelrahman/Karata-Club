namespace KarataClub.Application.Features.BeltTests.Queries.GetMemberBeltTests;

public sealed class MemberBeltTestValidator:AbstractValidator<MemberBeltTestsQuery>
{
    public MemberBeltTestValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid'{PropertyName}'");
        RuleFor(i => i.MemberId).Must(id => id != Guid.Empty).WithMessage("Provide a valid '{PropertyName}'");

    }
}
