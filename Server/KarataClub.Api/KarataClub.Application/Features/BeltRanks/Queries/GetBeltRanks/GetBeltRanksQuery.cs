using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

public sealed record GetBeltRanksQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "RankName", string SortDirection = "Asc",
string? RankName = null, decimal? FeesFrom = null,decimal?FeesTo=null
    )
    :IRequest<Result<PaginatedList< BeltRankFileDto>>>
{
}
