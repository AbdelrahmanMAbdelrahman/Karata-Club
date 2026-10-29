using KarataClub.Application.Features.Sessions.Dtos;
using KarataClub.Application.Features.Sessions.Mappers;
using Microsoft.Extensions.Caching.Hybrid;

namespace KarataClub.Application.Features.Sessions.Commands.CreateSession;

public sealed class CreateSessionHandler 
    (IAppDbContext context,
    ILogger<CreateSessionHandler>logger,
    TimeProvider timeProvider,HybridCache hybridCache)
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
        bool hasEnrollments = await context.Enrollments.AnyAsync(e => e.CourseId == courseFile.CourseId && e.Course.Active);
        if (!hasEnrollments)
        {
            logger.LogError("this course has no enrollment yet");
            return ApplicationErrors.NoEnrollmentsForThisCourse(request.CourseId);
        }
        bool IsSessionExist = await context.Sessions.AnyAsync(
            s=>s.SessionDate.Day==DateTime.UtcNow.Day&&
            s.CourseId== courseFile.CourseId
            );
        if (IsSessionExist)
        {
            logger.LogError("Session Already Exist");
            return ApplicationErrors.SessionAlreadyExist;
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
        await hybridCache.RemoveByTagAsync("session");
        return createSessionResult.Value.ToDto();

    }
}
