namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed record MemberAttendenceQuery(
    Guid SessionId,int PageNumber=1,int PageSize=10):IRequest<Result<PaginatedList< MemberAttendenceDto>>>
{
}
