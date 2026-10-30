using KarataClub.Domain.Common.Results;
using KarataClub.Domain.People.Instructors;

namespace KarataClub.Tests.Common.People.Instructors;

public static class InstructorFactory
{
    public static Result<Instructor> Create(Guid? personId=null, string qualifications=null) {
        return Instructor.Create(personId??Guid.NewGuid(),qualifications??"Gold medal");
    }
}
