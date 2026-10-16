

using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.People.Members.Queries.GetMembers;

public sealed record GetMembersQuery(
    int PageNumber=1,int PageSize=10,
    string SortColumn="Name",string SortDirection="Desc",
    string?Name=null,string? RankName=null
    ):IRequest<Result<PaginatedList<MemberDto>>>
{
}
