namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed class MemberAttendenceValidator: AbstractValidator<MemberAttendenceQuery>
{
    public MemberAttendenceValidator()
    {
        RuleFor(ma=>ma.SessionId).Must(id=>id!=Guid.Empty).WithMessage("Provide value for '{PropertyName}'");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 1000).WithMessage("Provide a valid Property Name");
        RuleFor(i => i.PageNumber).Must(p => p > 0 && p < 50).WithMessage("Provide a valid Property Name");
    }
}
