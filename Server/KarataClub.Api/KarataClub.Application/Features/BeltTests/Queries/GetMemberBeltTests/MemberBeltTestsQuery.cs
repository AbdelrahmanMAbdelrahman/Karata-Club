namespace KarataClub.Application.Features.BeltTests.Queries.GetMemberBeltTests;

public sealed record MemberBeltTestsQuery(Guid MemberId,int PageNumber = 1, int PageSize = 10,
string SortColumn = "MemberName", string SortDirection = "Asc",
string? MemberName = null, string? InstructorName = null, string? RankName = null,
decimal? FeesFrom = null, decimal? FeesTo = null):IRequest<Result<PaginatedList<BeltTestDto>>>
{
}
