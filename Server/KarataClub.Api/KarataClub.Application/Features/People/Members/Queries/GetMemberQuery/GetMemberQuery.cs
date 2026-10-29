
namespace KarataClub.Application.Features.People.Members.Queries.GetMembersQuery;

public sealed record GetMemberQuery(Guid MemberId) : ICachedQuery<Result<MemberDto>>
{
    public string CacheKey => $"Member-{MemberId}";

    public string[] Tags => ["Member"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
