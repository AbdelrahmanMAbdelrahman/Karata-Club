namespace KarataClub.Application.Features.Courses.Queries.GetAvailableCourses;

public sealed class AvailableCoursesValidator:AbstractValidator<AvailableCoursesQuery>
{
    public AvailableCoursesValidator()
    {
        RuleFor(c=>c.MemberId).Must(id=>id!=Guid.Empty)
            .WithMessage("Provide a valid '{PropertyName}'");
    }
}
