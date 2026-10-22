namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollment;

public sealed record EnrollmentQuery(Guid EnrollmentId):IRequest<Result<EnrollmentDto>>;
