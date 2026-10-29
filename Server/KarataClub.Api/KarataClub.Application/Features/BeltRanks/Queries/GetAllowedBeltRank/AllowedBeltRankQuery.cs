

namespace KarataClub.Application.Features.BeltRanks.Queries.GetAllowedBeltRank;

public sealed record AllowedBeltRankQuery(Guid MemberId) : ICachedQuery<Result<BeltRankFileDto>>
{
    public string CacheKey => $"BeltRank-{MemberId}";

    public string[] Tags => ["BeltRank"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
