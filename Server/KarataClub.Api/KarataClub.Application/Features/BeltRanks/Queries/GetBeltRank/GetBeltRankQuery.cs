using KarataClub.Domain.People.Members;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

public sealed record GetBeltRankQuery(Guid BeltRankId, CancellationToken ct) 
    : ICachedQuery<Result<BeltRankFileDto?>>
{
    public string CacheKey => $"BeltRank-{BeltRankId}";

    public string[] Tags => ["BeltRank"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
