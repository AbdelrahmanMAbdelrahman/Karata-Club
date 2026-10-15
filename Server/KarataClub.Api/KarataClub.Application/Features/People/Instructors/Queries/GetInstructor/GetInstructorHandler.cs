namespace KarataClub.Application.Features.People.Instructors.Queries.GetInstructor;

public sealed class GetInstructorHandler
    (IAppDbContext context,ILogger<GetInstructorHandler>logger)
    : IRequestHandler<GetInstructorQuery, Result<InstructorDto>>
{
    public async Task<Result<InstructorDto>> Handle(GetInstructorQuery request, CancellationToken cancellationToken)
    {
        var instructor = await context.Instructors
            .Include(m => m.Person)
            .FirstOrDefaultAsync(m => m.Id == request.InstructorId, cancellationToken);

        if (instructor is null)
        {
            logger.LogError("No instructor found for id = {instructorId}", request.InstructorId);
            return ApplicationErrors.InstructorNotFound(request.InstructorId);
        }
        return instructor.ToDto();
    }
}
