namespace KarataClub.Application.Features.People.Instructors.Commands.CreateInstructors;

public sealed record CreateInstructorCommand(
    string Name,string Email,string Phone,string Address,string Qualifications)
    :IRequest<Result<InstructorDto>>
{
}
