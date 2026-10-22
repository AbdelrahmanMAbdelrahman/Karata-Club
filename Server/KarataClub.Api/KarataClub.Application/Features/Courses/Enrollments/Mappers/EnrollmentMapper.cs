namespace KarataClub.Application.Features.Courses.Enrollments.Mappers;

public static class EnrollmentMapper
{
    public static EnrollmentDto ToDto(this CourseEnrollment enrollment)
    {
        return new EnrollmentDto(enrollment.Id,enrollment.Course.ToDto(),enrollment.Member.ToDto());
    }
    public static IQueryable<EnrollmentDto> ToDto(this IQueryable<CourseEnrollment>enrols)
    {
        return enrols.Select(
            enrollment =>
            new EnrollmentDto(enrollment.Id, enrollment.Course.ToDto(), enrollment.Member.ToDto())
            );
    }
}
