using KarataClub.Application.Features.Courses.Dtos;

namespace KarataClub.Application.Features.Courses.Commands.CreateCourses;

    public sealed record CreateCourseCommand(
        string CourseName,decimal Fees,int NumberOfSessions,decimal TotalHours,
        Stream? Image,string?ContentType,string? ImageName)
    :IRequest<Result<CourseFileDto>>;

 