namespace KarataClub.Domain.People.Members.MemberAttendencies;

public sealed class MemberAttendence : AuditEntity
{
    public Guid SessionId { get;private set; }
    public Guid MemberId { get; private set; }
    public Guid AttendenceId { get; private set; }
    public bool Exist { get; private set; }
    public Member Member { get; set; }
    public Attendence Attendence { get; set; }
    public Session Session = default!;
    private MemberAttendence()
    {

    }
    private MemberAttendence(Guid id,Guid sessionId, Guid memberId, Guid attendenceId, bool exist) : base(id)
    {
        this.MemberId = memberId;
        this.AttendenceId = attendenceId;
        this.SessionId = sessionId;
        this.Exist = exist;
    }
    public static Result<MemberAttendence> Create(Guid memberId, Guid sessionId, Guid attendenceId, bool exist = false)
    {
        if (memberId == Guid.Empty) return MemberAttendenceErrors.InvalidMemberId(memberId);
        if (attendenceId == Guid.Empty) return MemberAttendenceErrors.InvalidAttendenceId(attendenceId);
        if (sessionId == Guid.Empty) return MemberAttendenceErrors.InvalidSessionId(sessionId);
        return new MemberAttendence(Guid.NewGuid(), sessionId,memberId, attendenceId, exist);
    }

}
