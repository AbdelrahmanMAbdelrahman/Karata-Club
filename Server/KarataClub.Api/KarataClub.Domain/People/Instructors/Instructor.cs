using KarataClub.Domain.BeltTests;

namespace KarataClub.Domain.People.Instructors;

public class Instructor : AuditEntity
{
    public Guid PersonId { get;private set; }
    public string? Qualifications { get; private set; } = default!;
    public Person Person { get;  set; }=default!;
    public ICollection< BeltTest> BeltTests = [];

    public Instructor(){}
    public Instructor(Guid id,Guid personId,string qualifications):base(id){
    PersonId = personId;
        Qualifications = qualifications;
    }
    public Result<Instructor> Create(Guid personId, string qualifications) {
        if (personId == Guid.Empty) return InstructorErrors.InvalidInstructorId;
        return new Instructor(Guid.NewGuid(), personId, qualifications);
    }
}
