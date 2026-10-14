namespace KarataClub.Application.Features.People.Members.Commands.UpdateMembers;

public class UpdateMemberValidator:AbstractValidator<UpdateMemberCommand>
{
    public UpdateMemberValidator()
    {
        RuleFor(m => m.MemberId).Must(m => m != Guid.Empty).WithMessage("Provid a valid '{PropertyName}'");
        RuleFor(m => m.Name).NotEmpty().Length(3, 100).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Phone).NotEmpty().Length(15, 20).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Email).Length(15, 50).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");
        RuleFor(m => m.Address).NotEmpty().Length(3, 255).WithMessage("Provide a valid '{PropertyName}' with length from '{MinLength}' : '{MaxLength}'");

    }
}
