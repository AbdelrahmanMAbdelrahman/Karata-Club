namespace KarataClub.Application.Features.MemberAttendencies.Commands.CreateMemberAttendence;

public sealed class CreateMemberAttendenceValidator:AbstractValidator<CreateMemberAttendenceCommand>
{
    public CreateMemberAttendenceValidator()
    {
        RuleFor(ma=>ma.SessionId).Must(id=>id!=Guid.Empty)
            .WithMessage("Provide a valid '{PropertyName}'");
    }
}
