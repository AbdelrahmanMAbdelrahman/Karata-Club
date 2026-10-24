using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Application.Features.Courses.Dtos;

public sealed record CourseDto(
   Guid CourseId,string CourseName,decimal Fees,bool Active,decimal TotalHours,int NumberOfSessions,
   DateTimeOffset StartAt,DateTimeOffset EndAt,Priority Priority)
{
}
