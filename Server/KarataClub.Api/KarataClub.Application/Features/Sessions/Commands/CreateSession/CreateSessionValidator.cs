using KarataClub.Application.Features.Sessions.Queries.GetSession;

namespace KarataClub.Application.Features.Sessions.Commands.CreateSession;

public sealed class CreateSessionValidator:AbstractValidator<CreateSessionCommand>
{
    public CreateSessionValidator()
    {
        RuleFor(s=>s.CourseId).Must(id=>id!=Guid.Empty).WithMessage("Provide a valid '{PropertyName}'");
        RuleFor(s=>s.NumberOfHours).Must(h=>h>0 && h <13).WithMessage("Provide a valid '{PropertyName}'");
    }
}
