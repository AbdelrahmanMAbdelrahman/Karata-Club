using KarataClub.Application.Features.Sessions.Dtos;

namespace KarataClub.Application.Features.Sessions.Queries.GetSessions;

public sealed record SessionsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "CourseName", string SortDirection = "Asc",
string? CourseName = null, DateTime? FromSessionDate=null,
DateTime?ToSessionDate=null):IRequest<Result<PaginatedList<SessionDto>>>
{
}
