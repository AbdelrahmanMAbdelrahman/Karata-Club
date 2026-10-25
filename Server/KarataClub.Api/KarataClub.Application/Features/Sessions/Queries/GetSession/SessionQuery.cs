using KarataClub.Application.Features.Sessions.Dtos;

namespace KarataClub.Application.Features.Sessions.Queries.GetSession;

public sealed record SessionQuery(Guid SessionId):IRequest<Result<SessionDto>>
{
}
