
namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollments;

public sealed record EnrollmentsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "CourseName", string SortDirection = "Asc",
string? CourseName = null, string? MemberName = null,
decimal? FeesFrom = null, decimal? FeesTo = null
)
: ICachedQuery<Result<PaginatedList<EnrollmentDto>>>
{
    public string CacheKey =>
          $"p:{PageNumber}-pa:{PageSize}-" +
          $"sc:{SortColumn}-sd:{SortDirection}-" +
          $"cn:{CourseName}-mn:{MemberName}-" +
          $"ff:{FeesFrom}-ft:{FeesTo}-";

    public string[] Tags => ["Enrollment"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
