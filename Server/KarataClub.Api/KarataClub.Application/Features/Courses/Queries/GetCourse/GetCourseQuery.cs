namespace KarataClub.Application.Features.Courses.Queries.GetCourse;

public sealed record GetCourseQuery(Guid CourseFileId,CancellationToken ct):IRequest<Result<CourseFileDto>>
{
}
