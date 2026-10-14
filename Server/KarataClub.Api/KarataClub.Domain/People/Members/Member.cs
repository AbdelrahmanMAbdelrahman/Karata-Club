namespace KarataClub.Domain.People.Members;
public class Member : AuditEntity
{
    public Guid PersonId { get;private set; }
    public bool Active { get;private set; }
    public Guid? LastBeltRankId { get;private set; }
    public Person Person { get; set; }= default!;
    public BeltRank LastBeltRank { get; set; } = default!;
    public ICollection<CourseEnrollment> CourseEnrollments = default!;

    public ICollection<BeltTest> BeltTests=default!;
    public ICollection<Attendance> Attendances = default!;
    public ICollection<Payment> Payments = [];
    public ICollection<Subscription> Subscriptions = [];
    private Member(){}
    private Member(Guid id,Guid personId ,Guid? lastBeltRankId, bool? active=true) :base(id){
        PersonId = personId;
        Active = active??true;
        LastBeltRankId = lastBeltRankId;
    }

    public static Result<Member> Create(Guid personId,Guid? lastBeltRankId=null, bool? active=true) {
        if (personId == Guid.Empty) return MemberErrors.InvalidPersonId;
        //if (lastBeltRankId == Guid.Empty) return MemberErrors.InvalidLastBeltRankId;

        return new Member(Guid.NewGuid(),personId,lastBeltRankId, active);
    }

    
}

