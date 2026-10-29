namespace KarataClub.Application.Features.Courses.Queries.GetAvailableCourses;

public sealed record AvailableCoursesQuery(Guid MemberId) : ICachedQuery<Result<CourseFileDto>>
{
    public string CacheKey => $"Course-{MemberId}";

    public string[] Tags => ["Course"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
