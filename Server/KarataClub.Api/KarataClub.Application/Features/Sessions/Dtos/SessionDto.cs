namespace KarataClub.Application.Features.Sessions.Dtos;

public sealed record SessionDto(
    Guid SessionId,CourseDto Course,int NumberOfHours,DateTimeOffset SessionDate);


