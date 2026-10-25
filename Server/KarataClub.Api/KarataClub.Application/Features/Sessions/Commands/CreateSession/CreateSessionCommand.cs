using KarataClub.Application.Features.Sessions.Dtos;

namespace KarataClub.Application.Features.Sessions.Commands.CreateSession;

public sealed record CreateSessionCommand(Guid CourseId,int NumberOfHours):IRequest<Result<SessionDto>>
{
}
 