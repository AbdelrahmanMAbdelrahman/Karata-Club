namespace KarataClub.Application.Features.People.Members.Queries.GetMembersQuery;

public sealed class GetMemberValidator:AbstractValidator<GetMemberQuery>
{
    public GetMemberValidator()
    {
        RuleFor(m => m.MemberId).Must(i => i != Guid.Empty);
    }
}
