namespace KarataClub.Application.Features.Courses.Queries.GetCourse;

public sealed class GetCourseValidator:AbstractValidator<GetCourseQuery>
{
    public GetCourseValidator()
    {
        RuleFor(c => c.CourseFileId).Must(id => id != Guid.Empty).WithMessage("Must provide a valid '{PropertyName}'");
    }
}
