namespace KarataClub.Application.Features.Courses.Dtos;

public sealed record CourseDto(
   Guid CourseId,string CourseName,decimal Fees,decimal TotalHours,int NumberOfSessions)
{
}
