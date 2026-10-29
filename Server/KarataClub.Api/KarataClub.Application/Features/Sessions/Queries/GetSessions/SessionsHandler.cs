using KarataClub.Application.Features.Sessions.Dtos;
using KarataClub.Application.Features.Sessions.Mappers;

namespace KarataClub.Application.Features.Sessions.Queries.GetSessions;

public sealed class SessionsHandler
    (IAppDbContext context,ILogger<SessionsHandler> logger)
    : IRequestHandler<SessionsQuery, Result<PaginatedList<SessionDto>>>
{
    public async Task<Result<PaginatedList<SessionDto>>> Handle(SessionsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Session> query = context.Sessions
                .Include(m => m.Course)
                .AsNoTracking();
        query = ApplyFilter(query, request.CourseName,request.FromSessionDate,request.ToSessionDate);
        query = ApplySorting(query, request.SortColumn, request.SortDirection);
        Result<PaginatedList<SessionDto>> sessions = await PaginatedList<SessionDto>.Create(
             query.OrderBy(s=>s.SessionDate).ToDto(), request.PageNumber, request.PageSize
             );

        return sessions;
    }

    private IQueryable<Session> ApplyFilter(IQueryable<Session> query, string? courseName,
         DateTime? fromSessionDate,DateTime? toSessionDate)
    {
        if (!string.IsNullOrWhiteSpace(courseName))
            query = query.Where(q => q.Course.CourseName.Contains(courseName));
        if (fromSessionDate.HasValue)
            query.Where(q => q.SessionDate >= fromSessionDate);
        if(toSessionDate.HasValue)
            query.Where(q => q.SessionDate <= toSessionDate);


        return query;
    }

    private IQueryable<Session> ApplySorting(IQueryable<Session> query, string sortColumn, string sortDirection)
    {
        bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
        query = sortColumn switch
        {
            "CourseName" => desc ? query.OrderByDescending(q => q.Course.CourseName) :
            query.OrderBy(q => q.Course.CourseName),
            "SessionDate" => desc ? query.OrderByDescending(q => q.SessionDate) : query.OrderBy(q => q.SessionDate),
            _ => desc ? query.OrderByDescending(q => q.SessionDate) :
            query.OrderBy(q => q.SessionDate)
        };
        return query;
    }
}
