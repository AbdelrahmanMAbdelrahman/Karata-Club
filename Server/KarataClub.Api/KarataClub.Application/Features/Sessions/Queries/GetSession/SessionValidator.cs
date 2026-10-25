namespace KarataClub.Application.Features.Sessions.Queries.GetSession;

public sealed class SessionValidator:AbstractValidator<SessionQuery>
{
    public SessionValidator()
    {
        RuleFor(s=>s.SessionId).Must(id=>id!=Guid.Empty)
            .WithMessage("Provide a valid '{PropertyName}'");
    }
}
