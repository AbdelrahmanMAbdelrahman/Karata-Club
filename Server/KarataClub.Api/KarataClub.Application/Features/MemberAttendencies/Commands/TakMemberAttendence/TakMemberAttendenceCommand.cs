namespace KarataClub.Application.Features.MemberAttendencies.Commands.TakMemberAttendence;

public sealed record TakMemberAttendenceCommand(Guid SessionId,Dictionary<Guid,bool> MemberAttendence) 
    :IRequest< Result<Updated>>
{
}
