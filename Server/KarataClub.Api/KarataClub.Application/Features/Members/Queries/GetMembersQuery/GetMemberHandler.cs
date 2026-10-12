
namespace KarataClub.Application.Features.Members.Queries.GetMembersQuery;

public sealed class GetMemberHandler : IRequestHandler<GetMemberQuery, Result<MemberDto>>
{
    public Task<Result<MemberDto>> Handle(GetMemberQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
