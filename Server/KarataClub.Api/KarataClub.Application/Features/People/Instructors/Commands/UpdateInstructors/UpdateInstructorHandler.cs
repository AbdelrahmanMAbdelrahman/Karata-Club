
using Microsoft.Extensions.Logging;

namespace KarataClub.Application.Features.People.Instructors.Commands.UpdateInstructors;

public sealed class UpdateInstructorHandler
    (IAppDbContext context,ILogger<UpdateInstructorHandler> logger)
    : IRequestHandler<UpdateInstructorCommand, Result<Updated>>
{
    public async Task<Result<Updated>> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = await context.Instructors.Include(m => m.Person)
                 .FirstOrDefaultAsync(i => i.Id == request.InstructorId);
        if (instructor is null)
        {
            logger.LogError("No Instructor found for id = {InstructorId}", request.InstructorId);
            return ApplicationErrors.InstructorNotFound(request.InstructorId);
        }
        Result<Updated> updatePersonResult = instructor.Person.Update(request.Name, request.Email, request.Phone, request.Address);
        if (updatePersonResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", updatePersonResult.Errors));
            return updatePersonResult.Errors;
        }
        Result<Updated> updateInstructorResult = instructor.Update(request.Qualifications);
        if (updateInstructorResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", updateInstructorResult.Errors));
            return updateInstructorResult.Errors;
        }
        await context.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
