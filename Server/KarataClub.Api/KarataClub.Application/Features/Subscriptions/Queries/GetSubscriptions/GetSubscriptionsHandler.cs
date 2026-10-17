using KarataClub.Domain.Common.Models;
using MediatR;

namespace KarataClub.Application.Features.Subscriptions.Queries.GetSubscriptions;

public sealed class GetSubscriptionsHandler
    (IAppDbContext context)
    : IRequestHandler<GetSubscriptionsQuery, Result<PaginatedList<SubscriptionDto>>>
{
    public async Task<Result<PaginatedList<SubscriptionDto>>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Subscription> query = context.Subscriptions
            .Include(m => m.Member)
              .ThenInclude(m=>m.Person)
            .Include(m => m.Member)
              .ThenInclude(m=>m.LastBeltRank)
            .AsNoTracking();
        query = ApplyFilter(query, request.Name, request.RankName,request.StartDateFrom,request.StartDateTo,request.Active);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<SubscriptionDto>> Subscriptions = await PaginatedList<SubscriptionDto>.Create(
             query.ToDto(), request.PageNumber, request.PageSize
             );

        return Subscriptions;
    }

    private IQueryable<Subscription> ApplyFilter(IQueryable<Subscription> query, string? name, 
        string? rankName, DateTimeOffset? startDateFrom, DateTimeOffset? startDateTo, bool? active)
    {
        query = query.Where(q=>q.Member.Active);
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(q => q.Member.Person.Name.Contains(name));
        if (!string.IsNullOrWhiteSpace(rankName))
            query = query.Where(q => q.Member.LastBeltRank.RankName!.Contains(rankName));
        if (startDateFrom.HasValue)
        {
            query=query.Where(q=>q.StartDate>=startDateFrom.Value); 
        }
        if (startDateTo.HasValue)
        {
            query=query.Where(q=>q.StartDate<=startDateTo.Value); 
        }
        return query;
    }

    private IQueryable<Subscription> ApplySorting(IQueryable<Subscription> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "Name" => desc ? query.OrderByDescending(q => q.Member.Person.Name) : query.OrderBy(q => q.Member.Person.Name),
            "Fees" => desc ? query.OrderByDescending(q => q.Fees) : query.OrderBy(q => q.Fees),
            "StartDate" => desc ? query.OrderByDescending(q => q.StartDate) : query.OrderBy(q => q.StartDate),
            "RankName" => desc ? query.OrderByDescending(q => q.Member.LastBeltRank.RankName) : query.OrderBy(q => q.Member.LastBeltRank.RankName),
            _ => desc ? query.OrderByDescending(q => q.Member.Person.Name) : query.OrderBy(q => q.Member.Person.Name)
        };
        return query;
    }

   

}
