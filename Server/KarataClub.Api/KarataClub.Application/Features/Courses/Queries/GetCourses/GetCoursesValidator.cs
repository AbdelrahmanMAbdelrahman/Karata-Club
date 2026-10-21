using KarataClub.Application.Features.Courses.Queries.GetSubscriptions;

namespace KarataClub.Application.Features.Courses.Queries.GetCourses;

public sealed class GetCoursesValidator:AbstractValidator<GetCoursesQuery>
{
    public GetCoursesValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
