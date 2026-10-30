using KarataClub.Domain.Common.Results;
using KarataClub.Domain.People.Members.MemberAttendencies;
namespace KarataClub.Tests.Common.Attendencies;

public static class MemberAttendenceFactory
{
    public static Result<MemberAttendence>Create(
        Guid? memberId=null,
        Guid? sessionId=null,
        Guid? attendenceId=null,
        bool? exist = null)
    {
        return MemberAttendence.Create(
            memberId??Guid.NewGuid(),
            sessionId??Guid.NewGuid(),
            attendenceId??Guid.NewGuid(),
            true
            );
    }
}
