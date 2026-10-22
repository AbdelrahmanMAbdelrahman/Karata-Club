namespace KarataClub.Application.Features.Courses.Enrollments.Dtos;

public sealed record EnrollmentDto(Guid EnrollmentId,CourseDto Course,MemberDto Member);
