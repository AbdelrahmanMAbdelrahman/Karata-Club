namespace KarataClub.Application.Features.Courses.Queries.GetAvailableCourses;

public sealed record AvailableCoursesQuery(Guid MemberId):IRequest<Result<CourseFileDto>>
{
}
