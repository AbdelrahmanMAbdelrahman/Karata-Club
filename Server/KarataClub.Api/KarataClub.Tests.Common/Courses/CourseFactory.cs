using KarataClub.Domain.BeltTests.BeltRanks.Enums;
using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Courses;

namespace KarataClub.Tests.Common.Courses;

public static class CourseFactory
{
    public static Result<Course>Create(
        string? courseName=null, 
        decimal? fees=null,
        int? numberOfSessions=null,
        decimal? totalHours=null,
        DateTimeOffset? startAt=null,
        DateTimeOffset? endAt=null,
        Priority? priority = null)
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        return Course.Create(
            courseName??"white",
            fees??100,
            numberOfSessions??10,
            totalHours??10,
            startAt??fakeTimeProvider.GetUtcNow(),
            endAt??fakeTimeProvider.GetUtcNow().AddDays(30),
            priority??Priority.White
            );
    }
}
