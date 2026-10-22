namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollments;

public sealed record EnrollmentsQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "CourseName", string SortDirection = "Asc",
string? CourseName = null,string? MemberName=null,
decimal? FeesFrom = null, decimal? FeesTo = null
)
: IRequest<Result<PaginatedList<EnrollmentDto>>>
{
}
