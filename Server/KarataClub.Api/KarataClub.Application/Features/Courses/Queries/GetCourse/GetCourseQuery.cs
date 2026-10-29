using KarataClub.Domain.People.Members;

namespace KarataClub.Application.Features.Courses.Queries.GetCourse;

public sealed record GetCourseQuery(Guid CourseFileId,CancellationToken ct):ICachedQuery<Result<CourseFileDto>>
{
    public string CacheKey => $"Course-{CourseFileId}";

    public string[] Tags => ["Course"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
