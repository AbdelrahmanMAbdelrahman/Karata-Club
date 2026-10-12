namespace KarataClub.Application.Features.Members.Queries.GetMembersQuery;

public sealed class GetMemberValidator:AbstractValidator<GetMemberQuery>
{
    public GetMemberValidator()
    {
        RuleFor(m => m.MemberId).Must(i => i != Guid.Empty);
    }
}
