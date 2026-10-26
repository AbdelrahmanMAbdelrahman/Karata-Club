using KarataClub.Application.Features.Sessions.Dtos;
using KarataClub.Application.Features.Sessions.Mappers;

namespace KarataClub.Application.Features.Sessions.Commands.CreateSession;

public sealed class CreateSessionHandler 
    (IAppDbContext context,ILogger<CreateSessionHandler>logger,TimeProvider timeProvider)
    : IRequestHandler<CreateSessionCommand, Result<SessionDto>>
{
    async Task<Result<SessionDto>> IRequestHandler<CreateSessionCommand, 
        Result<SessionDto>>.Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
      CourseFile? courseFile = await context.CourseFiles
            .AsNoTracking()
            .Include(c=>c.Course)
            .FirstOrDefaultAsync(c => c.Id == request.CourseId && c.Course.Active);
        if (courseFile is null)
        {
            logger.LogError("No Course Available with id : {CourseId}", request.CourseId);
            return ApplicationErrors.CourseNotFound(request.CourseId);
        }

        Result<Session> createSessionResult = Session.Create(courseFile.Course.Id,request.NumberOfHours,
            timeProvider.GetUtcNow());
        if (createSessionResult.IsFailure)
        {
            logger.LogError(string.Join(", ", createSessionResult.Errors));
            return createSessionResult.Errors;
        }

        await context.Sessions.AddAsync(createSessionResult.Value);
        await context.SaveChangesAsync(cancellationToken);
        createSessionResult.Value.Course = courseFile.Course;
        return createSessionResult.Value.ToDto();

    }
}
