using KarataClub.Domain.BeltTests.BeltRanks;
using KarataClub.Domain.BeltTests.BeltRanks.Enums;
using KarataClub.Domain.Common.Results;

namespace KarataClub.Tests.Common.BeltRanks;

public static class BeltRankFactory
{
    public static Result<BeltRank> Create(
        string? rankName=null,
        decimal? testFees=null,
        Priority? rankPriority=null) {
        return BeltRank.Create(
            rankName??"white",
            testFees??100,
            rankPriority??Priority.White
            );
    }
}
