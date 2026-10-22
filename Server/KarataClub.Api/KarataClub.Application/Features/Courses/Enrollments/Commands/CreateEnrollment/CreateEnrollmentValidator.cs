namespace KarataClub.Application.Features.Courses.Enrollments.Commands.CreateEnrollment;

public sealed class CreateEnrollmentValidator:AbstractValidator<EnrollmentCommand>
{
    public CreateEnrollmentValidator()
    {
        RuleFor(e => e.CourseId).Must(id => id != Guid.Empty).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(e => e.MemberId).Must(id => id != Guid.Empty).WithMessage("Provide a valid '{PropertyName}'");
    }
}
