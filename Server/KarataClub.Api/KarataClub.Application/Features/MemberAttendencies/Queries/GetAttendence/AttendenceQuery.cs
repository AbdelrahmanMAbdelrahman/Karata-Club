namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed record AttendenceQuery(
    Guid SessionId) : ICachedQuery<Result<AttendenceDto>>
{
    public string CacheKey =>$"Attendence-{SessionId}";

    public string[] Tags => ["Attendence","MemberAttendence"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
