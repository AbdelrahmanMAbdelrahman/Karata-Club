namespace KarataClub.Application.Features.Courses.Dtos;

public sealed record CourseDto(
   Guid CourseId,string CourseName,decimal Fees,bool Active,decimal TotalHours,int NumberOfSessions)
{
}
