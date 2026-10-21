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
            
            .AsNoTracking();
        query = ApplyFilter(query, request.Name, request.FeesFrom,request.FeesTo);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<SubscriptionDto>> Courses = await PaginatedList<SubscriptionDto>.Create(
             query.ToDto(), request.PageNumber, request.PageSize
             );

        return Courses;
    }

    private IQueryable<Subscription> ApplyFilter(IQueryable<Subscription> query, string? courseName, 
         decimal? feesFrom, decimal? feesTo)
    {
        if (!string.IsNullOrWhiteSpace(courseName))
            query = query.Where(q => q.Member.Person.Name.Contains(courseName));
        
        if (feesFrom.HasValue)
        {
            query=query.Where(q=>q.Fees>=feesFrom.Value); 
        }
        if (feesTo.HasValue)
        {
            query=query.Where(q=>q.Fees<=feesTo.Value); 
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
