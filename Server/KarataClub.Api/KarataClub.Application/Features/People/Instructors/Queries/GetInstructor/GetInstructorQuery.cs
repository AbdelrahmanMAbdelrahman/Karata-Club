

namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructor;

public sealed record GetInstructorQuery(Guid InstructorId) : ICachedQuery<Result<InstructorDto>>
{
    public string CacheKey => $"Instructor-{InstructorId}";

    public string[] Tags => ["Instructor"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
