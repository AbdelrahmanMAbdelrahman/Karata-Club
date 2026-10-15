namespace KarataClub.Application.Features.People.Instructors.Commands.UpdateInstructors;

public sealed record UpdateInstructorCommand(
   Guid InstructorId,string Name, string Email, string Phone, string Address, string Qualifications)
   : IRequest<Result<Updated>>
{
}
