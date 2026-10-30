using KarataClub.Domain.Common.Results;
using KarataClub.Domain.People.Members.Attendencies;

namespace KarataClub.Tests.Common.Attendencies;

public static class AttendenceFactory
{
    public static Result<Attendence>Create(Guid? sessionId = null)
    {
        return Attendence.Create(sessionId??Guid.NewGuid());
    }
}
