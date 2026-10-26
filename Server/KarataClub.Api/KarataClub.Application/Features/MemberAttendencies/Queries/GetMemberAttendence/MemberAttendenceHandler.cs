
namespace KarataClub.Application.Features.MemberAttendencies.Queries.GetMemberAttendence;

public sealed class MemberAttendenceHandler
    (IAppDbContext context,ILogger<MemberAttendenceHandler> logger)
    : IRequestHandler<MemberAttendenceQuery, Result<PaginatedList< MemberAttendenceDto>>>
{
    public async Task<Result<PaginatedList< MemberAttendenceDto>>> Handle(MemberAttendenceQuery request, CancellationToken cancellationToken)
    {
        IQueryable<MemberAttendence> memberAttendencies = context.MemberAttendencies
            .AsNoTracking()
            .Include(ma => ma.Member)
              .ThenInclude(m => m.Person)
            .Include(ma => ma.Member)
              .ThenInclude(m => m.LastBeltRank)
            .OrderBy(ma => ma.Id);
        Result< PaginatedList<MemberAttendenceDto>> memberAttendenceDtos = 
           await  PaginatedList<MemberAttendenceDto>.Create(
            memberAttendencies.ToDto(), request.PageNumber, request.PageSize
            );

        return memberAttendenceDtos.Value;
    }
}
