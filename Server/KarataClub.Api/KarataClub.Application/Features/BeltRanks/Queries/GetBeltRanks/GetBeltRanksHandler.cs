
using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

public sealed class GetBeltRanksHandler
    (IAppDbContext context)
    : IRequestHandler<GetBeltRanksQuery, Result<PaginatedList<BeltRankFileDto>>>
{
    public async Task<Result<PaginatedList<BeltRankFileDto>>> Handle(GetBeltRanksQuery request, CancellationToken cancellationToken)
    {
        IQueryable<BeltRankFile> query = context.BeltRankFiles
            .AsNoTracking();
        query = ApplyFilter(query, request.RankName, request.FeesFrom,request.FeesTo);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<BeltRankFileDto>> BeltRank = await PaginatedList<BeltRankFileDto>.Create(
             query.ToDto(), request.PageNumber, request.PageSize
             );

        return BeltRank;
    }

    private IQueryable<BeltRankFile> ApplyFilter(IQueryable<BeltRankFile> query, string? RankName, 
         decimal? feesFrom, decimal? feesTo)
    {
        if (!string.IsNullOrWhiteSpace(RankName))
            query = query.Where(q => q.BeltRank.RankName.Contains(RankName));
        if (feesFrom.HasValue)
        {
            query=query.Where(q=>q.BeltRank.TestFees>=feesFrom.Value); 
        }
        if (feesTo.HasValue)
        {
            query=query.Where(q=>q.BeltRank.TestFees<=feesTo.Value); 
        }
        return query;
    }

    private IQueryable<BeltRankFile> ApplySorting(IQueryable<BeltRankFile> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "RankName" => desc ? query.OrderByDescending(q => q.BeltRank.RankName) :
            query.OrderBy(q => q.BeltRank.RankName),
            "Fees" => desc ? query.OrderByDescending(q => q.BeltRank.TestFees) : query.OrderBy(q => q.BeltRank.TestFees),
            _ => desc ? query.OrderByDescending(q => q.BeltRank.RankName) :
            query.OrderBy(q => q.BeltRank.RankName)
        };
        return query;
    }

   

}
