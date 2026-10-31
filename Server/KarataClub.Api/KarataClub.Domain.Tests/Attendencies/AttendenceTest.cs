using KarataClub.Domain.People.Members.Attendencies;
using KarataClub.Tests.Common.Attendencies;

namespace KarataClub.Domain.Tests.Attendencies;

public  class AttendenceTest
{
    [Fact]
    public void CreateAttendence_ShouldPass_ForValidData()
    {
        Guid sessionId=Guid.NewGuid();
        var attendenceRes = AttendenceFactory.Create(sessionId);
        Assert.True(attendenceRes.IsSuccess);
        Attendence attendence = attendenceRes.Value;
        Assert.Equal(attendence.SessionId,sessionId);
    }
    [Fact]
    public void CreateAttendence_ShouldFail_ForValidInvalidSessionId()
    {
        Guid sessionId=Guid.Empty;
        var attendenceRes = AttendenceFactory.Create(sessionId);
        Assert.True(attendenceRes.IsFailure);
    }
 
}
