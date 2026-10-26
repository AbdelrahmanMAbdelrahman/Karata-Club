using KarataClub.Domain.Courses.Sessions;
using KarataClub.Domain.People.Members.MemberAttendencies;

namespace KarataClub.Domain.People.Members.Attendencies;

public class Attendence:AuditEntity
{
    public Guid SessionId { get;private set; }
    //public Guid MemberId { get; private set; }
    //public bool IsExist { get; private set; }
    public Session Session { get; set; } = default!;
    public ICollection<MemberAttendence> MemberAttendencies = default!;
    //public Member Member { get; set; } = default!;
    public Attendence(){}
    public Attendence(Guid id,Guid sessionId//,Guid memberid
        ):base(id){
    SessionId = sessionId; 
        //MemberId = memberid;
        //IsExist = false;
    }
    public static Result<Attendence> Create(Guid sessionId//, Guid memberId
        ) {
        if (sessionId == Guid.Empty) return AttendenceErrors.InvalidSessionId;
        //if (memberId == Guid.Empty) return AttendanceErrors.InvalidMemberId;
        return new Attendence(Guid.NewGuid(),sessionId);
    }
}
