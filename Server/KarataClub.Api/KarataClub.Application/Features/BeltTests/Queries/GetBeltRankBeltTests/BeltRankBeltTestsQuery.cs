namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltRankBeltTests;

public sealed record BeltRankBeltTestsQuery(Guid BeltRankId, int PageNumber = 1, int PageSize = 10,
string SortColumn = "MemberName", string SortDirection = "Asc",
string? MemberName = null, string? InstructorName = null, string? RankName = null,
decimal? FeesFrom = null, decimal? FeesTo = null) : ICachedQuery<Result<PaginatedList<BeltTestDto>>>
{
    public string CacheKey =>
          $"p:{PageNumber}-pa:{PageSize}-" +
        $"sc:{SortColumn}-sd:{SortDirection}-" +
        $"br:{BeltRankId}-mm:{MemberName}-" +
        $"in:{InstructorName}-rn:{RankName}-" +
        $"ff:{FeesFrom}-ft:{FeesTo}-" ;

    public string[] Tags => ["BeltTest"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
