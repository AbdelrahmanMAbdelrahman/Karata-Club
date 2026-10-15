namespace KarataClub.Application.Features.People.Instructors.Commands.CreateInstructors;

public sealed class CreateInstructorValidator:AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorValidator()
    {
        RuleFor(m => m.Name).NotEmpty().Length(3, 100).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Phone).NotEmpty().Length(15, 20).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Email).Length(15, 50).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Address).NotEmpty().Length(3, 255).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Qualifications).NotEmpty().Length(3, 255).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
    }
}
