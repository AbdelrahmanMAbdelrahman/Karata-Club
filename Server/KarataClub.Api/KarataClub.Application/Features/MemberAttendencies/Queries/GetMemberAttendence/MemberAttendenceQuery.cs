namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed record MemberAttendenceQuery(
    Guid SessionId, int PageNumber = 1, int PageSize = 10) 
    : ICachedQuery<Result<PaginatedList<MemberAttendenceDto>>>
{
    public string CacheKey =>
        $"p:{PageNumber}-pa:{PageSize}-" +
        $"sId:{SessionId}"
        ;

    public string[] Tags => ["Attendence","MemberAttendence"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
