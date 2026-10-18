using KarataClub.Application.Features.Courses.Dtos;
using KarataClub.Domain.Common.Models;

namespace KarataClub.Application.Features.Courses.Queries.GetSubscriptions;

public sealed record GetCoursesQuery(int PageNumber = 1, int PageSize = 10,
string SortColumn = "CourseName", string SortDirection = "Asc",
string? CourseName = null, decimal? FeesFrom = null,decimal?FeesTo=null
    )
    :IRequest<Result<PaginatedList< CourseFileDto>>>
{
}
