

namespace KarataClub.Application.Features.MemberAttendencies.Dtos;

public sealed record AttendenceDto(
    Guid AttendenceId,SessionDto Session//,PaginatedList<MemberAttendenceDto> MemberAttendencies
    );
