namespace KarataClub.Application.Features.Courses.Commands.CreateCourses;

public sealed class CreateCourseValidator:AbstractValidator<CreateCourseCommand>
{
    public CreateCourseValidator()
    {
        RuleFor(c=>c.NumberOfSessions).Must(s=>s>0).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(c=>c.Fees).Must(s=>s>0).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(c=>c.TotalHours).Must(s=>s>0).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(c => c.CourseName).NotEmpty().Must(n => n.Length > 3 && n.Length < 255)
            .WithMessage("Provide a valid value for '{PropertyName}'");
    }
}
