using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

public sealed record GetBeltRanksQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "RankName", string SortDirection = "Asc",
string? RankName = null, decimal? FeesFrom = null, decimal? FeesTo = null
    )
    : ICachedQuery<Result<PaginatedList<BeltRankFileDto>>>
{
    public string CacheKey => 
        $"p:{PageNumber}-pa:{PageSize}-"+
        $"sc:{SortColumn}-sd:{SortDirection}-"+
        $"rn:{RankName}-"+
        $"ff:{FeesFrom}-ft:{FeesTo}";

    public string[] Tags => ["BeltRank"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
