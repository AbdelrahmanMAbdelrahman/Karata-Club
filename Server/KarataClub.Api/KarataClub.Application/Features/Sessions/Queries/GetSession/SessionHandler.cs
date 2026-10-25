using KarataClub.Application.Features.Sessions.Dtos;
using KarataClub.Application.Features.Sessions.Mappers;

namespace KarataClub.Application.Features.Sessions.Queries.GetSession;

public sealed class SessionHandler (
    IAppDbContext context,ILogger<SessionHandler> logger
    ): IRequestHandler<SessionQuery, Result<SessionDto>>
{
    public async Task<Result<SessionDto>> Handle(SessionQuery request, CancellationToken cancellationToken)
    {
        Session? session = await context.Sessions
             .AsNoTracking()
             .Include(s => s.Course)
             .FirstOrDefaultAsync(s=>s.Id==request.SessionId);
        if(session is null)
        {
            logger.LogError("No Session found with id : {SessionId}", request.SessionId);
            return ApplicationErrors.SessionNotFound(request.SessionId);
        }

        return session.ToDto();
    }
}
