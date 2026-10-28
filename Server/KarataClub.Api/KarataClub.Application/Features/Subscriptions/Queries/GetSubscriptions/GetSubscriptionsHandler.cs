using KarataClub.Application.Features.Courses.Dtos;
using KarataClub.Application.Features.Courses.Mappers;
using KarataClub.Application.Features.Courses.Queries.GetSubscriptions;
using KarataClub.Domain.Common.Models;
using MediatR;

namespace KarataClub.Application.Features.Courses.Queries.GetCourses;

public sealed class GetSubscriptionsHandler
    (IAppDbContext context)
    : IRequestHandler<GetSubscriptionsQuery, Result<PaginatedList<SubscriptionDto>>>
{
    public async Task<Result<PaginatedList<SubscriptionDto>>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Subscription> query = context.Subscriptions
            .Include(s => s.Member)
              .ThenInclude(m=>m.Person)
            .Include(s=>s.Member)
              .ThenInclude(s=>s.LastBeltRank)
            .AsNoTracking();
        query = ApplyFilter(query, request.Name,request.RankName, request.FromDate,request.ToDate);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<SubscriptionDto>> Courses = await PaginatedList<SubscriptionDto>.Create(
             query.ToDto(), request.PageNumber, request.PageSize
             );

        return Courses;
    }

    private IQueryable<Subscription> ApplyFilter(IQueryable<Subscription> query, string? memberName, 
         string?rankName,DateTime? fromDate, DateTime? toDate)
    {
        if (!string.IsNullOrWhiteSpace(memberName))
            query = query.Where(q => q.Member.Person.Name.Contains(memberName));
        if (!string.IsNullOrWhiteSpace(rankName))
            query = query.Where(q => q.Member.LastBeltRank.RankName.Contains(rankName));
        
        if (fromDate.HasValue)
        {
            query=query.Where(q=>q.StartDate>=fromDate.Value); 
        }
        if (toDate.HasValue)
        {
            query=query.Where(q=>q.StartDate<=toDate.Value); 
        }
        return query;
    }

    private IQueryable<Subscription> ApplySorting(IQueryable<Subscription> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "CourseName" => desc ? query.OrderByDescending(q => q.Member.Person.Name) :
            query.OrderBy(q => q.Member.Person.Name),
            "Fees" => desc ? query.OrderByDescending(q => q.Fees) : query.OrderBy(q => q.Fees),
            _ => desc ? query.OrderByDescending(q => q.Member.Person.Name) :
            query.OrderBy(q => q.Member.Person.Name)
        };
        return query;
    }

   

}
