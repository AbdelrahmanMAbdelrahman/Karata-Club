using KarataClub.Application.Features.Courses.Dtos;
using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Application.Features.Courses.Commands.CreateCourses;

    public sealed record CreateCourseCommand(
        string CourseName,decimal Fees,int NumberOfSessions,decimal TotalHours,
        DateTimeOffset StartAt,Priority Priority,
        Stream? Image,string?ContentType,string? ImageName)
    :IRequest<Result<CourseFileDto>>;

 