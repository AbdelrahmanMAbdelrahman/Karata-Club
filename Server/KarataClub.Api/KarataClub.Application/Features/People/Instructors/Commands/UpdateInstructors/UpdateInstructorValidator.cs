namespace KarataClub.Application.Features.People.Instructors.Commands.UpdateInstructors;

public sealed class UpdateInstructorValidator:AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorValidator()
    {
        RuleFor(i=>i.InstructorId).Must(i=>i!=Guid.Empty).WithMessage("Provide a valid Instructor Id");
        RuleFor(i => i.Name).NotEmpty().Length(3, 100).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(i => i.Phone).NotEmpty().Length(15, 20).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(i => i.Email).Length(15, 50).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(i => i.Address).NotEmpty().Length(3, 255).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(i => i.Qualifications).NotEmpty().Length(3, 255).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
    }
}
