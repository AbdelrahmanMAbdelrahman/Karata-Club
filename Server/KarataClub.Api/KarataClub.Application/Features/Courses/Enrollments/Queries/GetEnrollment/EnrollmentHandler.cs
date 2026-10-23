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

        return enrollment.ToDto();
    }
}
