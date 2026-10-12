namespace KarataClub.Application.Features.Members.Queries.GetMembersQuery;

public sealed record GetMemberQuery(Guid MemberId):IRequest<Result<MemberDto>>
{
}
