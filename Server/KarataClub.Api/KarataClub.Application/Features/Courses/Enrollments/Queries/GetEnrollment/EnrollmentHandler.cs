using KarataClub.Domain.Courses.Sessions;

namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollment;

public sealed class EnrollmentHandler(
    IAppDbContext context,ILogger<EnrollmentHandler> logger
    ) : IRequestHandler<EnrollmentQuery, Result<EnrollmentDto>>
{
    public async Task<Result<EnrollmentDto>> Handle(EnrollmentQuery request, CancellationToken cancellationToken)
    {
        CourseEnrollment? enrollment = await context.Enrollments
             .Include(e => e.Course)
             .Include(e => e.Member)
              .ThenInclude(m => m.Person)
              .FirstOrDefaultAsync(e=>e.Id== request.EnrollmentId,cancellationToken);

        if (enrollment is null)
        {
            logger.LogError("no Enrollment found for Enrollment id = {EnrollmentId}",request.EnrollmentId);
            return ApplicationErrors.EnrollmentNotFound(request.EnrollmentId);
        }
        enrollment.Course.NumberOfEnrollments = await context.Enrollments.CountAsync(
            e => e.CourseId == enrollment.CourseId, cancellationToken);
        return enrollment.ToDto();
    }
}
