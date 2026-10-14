namespace KarataClub.Application.Features.People.Members.Queries.GetMembersQuery;

public sealed class GetMemberHandler(IAppDbContext context,ILogger <GetMemberHandler>logger) : IRequestHandler<GetMemberQuery, Result<MemberDto>>
{
    public async Task<Result<MemberDto>> Handle(GetMemberQuery request, CancellationToken cancellationToken)
    {
        var member = await context.Members
            .Include(m=>m.Person)
            .Include(m=>m.LastBeltRank)
            .FirstOrDefaultAsync(m=>m.Id==request.MemberId,cancellationToken);

        if(member is null)
        {
            logger.LogError("No Member found for id = {MemberId}", request.MemberId);
            return ApplicationErrors.MemberNotFound(request.MemberId);
        }
        return member.ToDto();
    }
}
