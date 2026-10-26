using KarataClub.Domain.People.Members.MemberAttendencies;

namespace KarataClub.Application.Features.MemberAttendencies.Mappers;

public static class MemberAttendenciesMappers
{
    public static MemberAttendenceDto ToDto(this MemberAttendence memberAttendence)
    {
        return new MemberAttendenceDto(
            memberAttendence.Id,memberAttendence.Member.ToDto(),memberAttendence.Exist);
    }
    public static AttendenceDto ToDto(this Attendence attendence) { 
    return new AttendenceDto(attendence.Id,attendence.Session.ToDto());
    }

    public static IQueryable<MemberAttendenceDto> ToDto(this IQueryable<MemberAttendence> members) {
        return members.Select(
            m=> new MemberAttendenceDto(
            m.Id, m.Member.ToDto(), m.Exist)
            );
    }
}
