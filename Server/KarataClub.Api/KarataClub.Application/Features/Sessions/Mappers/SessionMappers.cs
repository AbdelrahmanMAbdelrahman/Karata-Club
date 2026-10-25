using KarataClub.Application.Features.Sessions.Dtos;
using KarataClub.Domain.Courses.Sessions;
namespace KarataClub.Application.Features.Sessions.Mappers;

public static class SessionMappers
{
    public static SessionDto ToDto(this Session session)
    {
        return new SessionDto(session.Id,session.Course.ToDto(),session.NumberOfHours,session.SessionDate);
    }

    public static IQueryable<SessionDto>ToDto(this IQueryable<Session> sessions)
    {
        return sessions.Select(
            session => new SessionDto(session.Id, session.Course.ToDto(), session.NumberOfHours, session.SessionDate)
            );
    }
}
