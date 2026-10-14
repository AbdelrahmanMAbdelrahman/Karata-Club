using Microsoft.AspNetCore.Identity.Data;

namespace KarataClub.Application.Features.Identity.Quries.LoginQuerys;

public sealed class LoginValidator:AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(l=>l.Email).NotEmpty().Length(15,50).WithMessage("Provide Avalid '{PropertyName}' with length '{MinLength}' : '{MaxLength}'");
        RuleFor(l => l.Password).NotEmpty().Length(5, 40).WithMessage("Provide Avalid '{PropertyName}' with length '{MinLength}' : '{MaxLength}'");
    }
}
