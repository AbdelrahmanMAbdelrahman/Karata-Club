namespace KarataClub.Application.Features.Courses.Enrollments.Commands.CreateEnrollment;

public sealed record EnrollmentCommand(
    Guid CourseId,Guid MemberId,string?Notes):IRequest<Result<EnrollmentDto>>;
