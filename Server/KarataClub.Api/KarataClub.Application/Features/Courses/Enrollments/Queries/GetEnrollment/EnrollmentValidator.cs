namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollment;

public class EnrollmentValidator:AbstractValidator<EnrollmentQuery>
{
    public EnrollmentValidator()
    {
        RuleFor(e=>e.EnrollmentId).Must(id=>id!=Guid.Empty)
            .WithMessage("Must Provide a valid '{PropertyName}'");
    }
}
