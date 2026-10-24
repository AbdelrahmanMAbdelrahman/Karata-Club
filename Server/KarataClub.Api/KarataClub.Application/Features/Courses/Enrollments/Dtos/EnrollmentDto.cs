namespace KarataClub.Application.Features.Courses.Enrollments.Dtos;

public sealed record EnrollmentDto(Guid EnrollmentId,
    DateTimeOffset EnrollmentDate,DateTimeOffset EndDate,
    CourseDto Course,MemberDto Member);
