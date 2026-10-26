

namespace KarataClub.Application.Features.MemberAttendencies.Dtos;

public sealed record MemberAttendenceDto(Guid MemberAttendenceId
    ,MemberDto Member,bool Exist);