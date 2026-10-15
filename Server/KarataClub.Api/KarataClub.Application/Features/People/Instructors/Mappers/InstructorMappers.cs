using KarataClub.Domain.People.Instructors;

namespace KarataClub.Application.Features.People.Instructors.Mappers;

public static class InstructorMappers
{
    public static InstructorDto ToDto(this Instructor instructor)
    {
        return new InstructorDto(instructor.Id,instructor.Qualifications??"N/A",instructor.Person.ToDto());
    }
    public static IQueryable<InstructorDto> ToDto(this IQueryable<Instructor> instructors)
    {
        return instructors.Select(instructor=> 
        new InstructorDto(instructor.Id, instructor.Qualifications ?? "N/A", instructor.Person.ToDto()));
        
    }
}
