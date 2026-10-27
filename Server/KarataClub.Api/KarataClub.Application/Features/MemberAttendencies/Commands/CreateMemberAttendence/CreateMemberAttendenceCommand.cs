using KarataClub.Application.Features.MemberAttendencies.Dtos;

namespace KarataClub.Application.Features.MemberAttendencies.Commands.CreateMemberAttendence;

public sealed record CreateMemberAttendenceCommand(Guid SessionId):IRequest<Result<AttendenceDto>>
{
}
