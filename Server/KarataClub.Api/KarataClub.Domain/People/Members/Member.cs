namespace KarataClub.Domain.People.Members;
public class Member : AuditEntity
{
    public Guid PersonId { get;private set; }
    public bool Active { get;private set; }
    public string EmergencyContactInfo { get; private set; } = default!;
    public Guid? LastBeltRankId { get;private set; }
    public Person Person { get; set; }= default!;
    public BeltRank LastBeltRank { get; set; } = default!;
    public ICollection<CourseEnrollment> CourseEnrollments = default!;

    public ICollection<BeltTest> BeltTests=default!;
    public ICollection<Attendance> Attendances = default!;
    public ICollection<Payment> Payments = [];
    public ICollection<Subscription> Subscriptions = [];
    private Member(){}
    private Member(Guid id,Guid personId ,string emergencyContactInfo,Guid? lastBeltRankId, bool? active=true) :base(id){
        PersonId = personId;
        Active = active??true;
        EmergencyContactInfo = emergencyContactInfo;
        LastBeltRankId = lastBeltRankId;
    }

    public static Result<Member> Create(Guid personId,  string emergencyContactInfo,Guid? lastBeltRankId=null, bool? active=true) {
        if (string.IsNullOrWhiteSpace(emergencyContactInfo)) return MemberErrors.InvalidEmergencyContactInfo;
        if (personId == Guid.Empty) return MemberErrors.InvalidPersonId;
        //if (lastBeltRankId == Guid.Empty) return MemberErrors.InvalidLastBeltRankId;

        return new Member(Guid.NewGuid(),personId,emergencyContactInfo,lastBeltRankId, active);
    }
}

