namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTests;

public sealed record BeltTestsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "MemberName", string SortDirection = "Asc",
string? MemberName = null, string? InstructorName = null, string? RankName = null,
decimal? FeesFrom = null, decimal? FeesTo = null):IRequest<Result<PaginatedList<BeltTestDto>>>
{
}
