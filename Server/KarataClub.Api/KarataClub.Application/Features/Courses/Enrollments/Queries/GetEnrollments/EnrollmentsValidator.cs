namespace KarataClub.Application.Features.Courses.Enrollments.Queries.GetEnrollments;

public sealed class EnrollmentsValidator:AbstractValidator<EnrollmentsQuery>
{
    public EnrollmentsValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
