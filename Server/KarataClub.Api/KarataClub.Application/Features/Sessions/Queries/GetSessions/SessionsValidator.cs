namespace KarataClub.Application.Features.Sessions.Queries.GetSessions;

public sealed class SessionsValidator:AbstractValidator<SessionsQuery>
{
    public SessionsValidator()
    {
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
