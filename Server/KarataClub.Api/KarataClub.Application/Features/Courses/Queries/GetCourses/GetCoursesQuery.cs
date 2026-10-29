
namespace KarataClub.Application.Features.Courses.Queries.GetSubscriptions;

public sealed record GetCoursesQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "CourseName", string SortDirection = "Asc",
string? CourseName = null, decimal? FeesFrom = null, decimal? FeesTo = null
    )
    : ICachedQuery<Result<PaginatedList<CourseFileDto>>>
{

    public string CacheKey =>
        $"p:{PageNumber}-pa:{PageSize}-" +
        $"sc:{SortColumn}-sd:{SortDirection}-"+
        $"cn:{CourseName}-ff:{FeesFrom}-ft:{FeesTo}"
        ;

    public string[] Tags => ["Course"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
