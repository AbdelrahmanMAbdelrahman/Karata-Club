using KarataClub.Application.Features.Sessions.Dtos;

namespace KarataClub.Application.Features.Sessions.Queries.GetSessions;

public sealed record SessionsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "CourseName", string SortDirection = "Asc",
string? CourseName = null, DateTime? FromSessionDate = null,
DateTime? ToSessionDate = null) : ICachedQuery<Result<PaginatedList<SessionDto>>>
{
    public string CacheKey =>
        $"p:{PageNumber}-pa:{PageSize}-" +
        $"sc:{SortColumn}-sd:{SortDirection}-"+
        $"cn:{CourseName}-fsd:{FromSessionDate}-tsd:{ToSessionDate}";

    public string[] Tags =>["Session"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
