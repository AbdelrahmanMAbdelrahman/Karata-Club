namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed record AttendenceQuery(
    Guid SessionId):IRequest<Result< AttendenceDto>>
{
}
