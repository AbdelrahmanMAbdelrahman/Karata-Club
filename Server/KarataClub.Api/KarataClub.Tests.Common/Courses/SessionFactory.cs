using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Courses.Sessions;

namespace KarataClub.Tests.Common.Courses;

public static class SessionFactory
{
    public static Result<Session>Create(
        Guid? courseId=null,
        int? numberOfHours=null,
        DateTimeOffset? sessionDate= null)
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        return Session.Create(
            courseId??Guid.NewGuid(),
            numberOfHours??1,
            sessionDate??fakeTimeProvider.GetUtcNow());
    }
}
