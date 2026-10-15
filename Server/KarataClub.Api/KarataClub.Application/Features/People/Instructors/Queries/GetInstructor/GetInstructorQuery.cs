

namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructor
{
   public sealed record GetInstructorQuery(Guid InstructorId):IRequest<Result<InstructorDto>>
    {
    }
}
