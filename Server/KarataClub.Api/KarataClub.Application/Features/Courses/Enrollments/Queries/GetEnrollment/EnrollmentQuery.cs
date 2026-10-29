namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollment;

public sealed record EnrollmentQuery(Guid EnrollmentId) : ICachedQuery<Result<EnrollmentDto>>
{
    public string CacheKey => $"Enrollment-{EnrollmentId}";

    public string[] Tags => ["Enrollment"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
