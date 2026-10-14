
namespace KarataClub.Application.Features.People.Members.Queries.GetMembersQuery;

public sealed record GetMemberQuery(Guid MemberId):IRequest<Result<MemberDto>>
{
}
