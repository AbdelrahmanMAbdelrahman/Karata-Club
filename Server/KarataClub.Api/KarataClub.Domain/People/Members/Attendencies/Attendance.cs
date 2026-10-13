using KarataClub.Domain.Courses.Sessions;

namespace KarataClub.Domain.People.Members.Attendencies;

public class Attendance:AuditEntity
{
    public Guid SessionId { get;private set; }
    public Guid MemberId { get; private set; }
    public bool IsExist { get; private set; }
    public Session Session { get; set; } = default!;
    public Member Member { get; set; } = default!;
    public Attendance(){}
    public Attendance(Guid sessionId,Guid memberid){
    SessionId = sessionId; MemberId = memberid;
        IsExist = false;
    }
    public Result<Attendance> Create(Guid sessionId, Guid memberId) {
        if (sessionId == Guid.Empty) return AttendanceErrors.InvalidSessionId;
        if (memberId == Guid.Empty) return AttendanceErrors.InvalidMemberId;
        return new Attendance(sessionId,memberId);
    }
}
