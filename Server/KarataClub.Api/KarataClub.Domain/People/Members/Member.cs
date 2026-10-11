namespace KarataClub.Domain.People.Members;
public class Member : AuditEntity
{
    public Guid PersonId { get;private set; }
    public bool Active { get;private set; }
    public string EmergencyContactInfo { get; private set; } = default!;
    public Guid LastBeltRankId { get;private set; }
    public Person Person { get; set; }= default!;
    public BeltRank LastBeltRank { get; set; } = default!;
    public BeltTest BeltTest=default!;
    public ICollection<Attendance> Attendances = default!;
    public ICollection<Payment> Payments = [];
    public Member(){}
    public Member(Guid id,Guid personId ,bool active,string emergencyContactInfo,Guid lastBeltRankId):base(id){
        PersonId = personId;
        Active = active;
        EmergencyContactInfo = emergencyContactInfo;
        LastBeltRankId = lastBeltRankId;
    }

    public Result<Member> Create(Guid personId, bool active, string emergencyContactInfo,Guid lastBeltRankId) {
        if (string.IsNullOrWhiteSpace(emergencyContactInfo)) return MemberErrors.InvalidEmergencyContactInfo;
        if (personId == Guid.Empty) return MemberErrors.InvalidPersonId;
        if (lastBeltRankId == Guid.Empty) return MemberErrors.InvalidLastBeltRankId;

        return new Member(Guid.NewGuid(),personId,active,emergencyContactInfo,lastBeltRankId);
    }
}

