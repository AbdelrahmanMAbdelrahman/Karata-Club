using KarataClub.Domain.BeltTests.BeltRanks;

namespace KarataClub.Application.Features.BeltRanks.Mappers;

public static class BeltRankMappers

{
    public static BeltRankDto? ToDto(this BeltRank? beltRank)
    {
        if (beltRank is null) return null;
        return new BeltRankDto(beltRank.Id,beltRank.RankName,beltRank.TestFees,beltRank.RankPriority);
    }
    public static BeltRankFileDto ToDto(this BeltRankFile beltRankFile) {
    ArgumentNullException.ThrowIfNull(nameof(beltRankFile));
        return new BeltRankFileDto(beltRankFile.BeltRank.ToDto(),beltRankFile.UploadedFileId);
    }
    public static IQueryable<BeltRankDto>ToDto(this IQueryable<BeltRank> beltRanks)
    {
        return beltRanks.Select(beltRank =>
        new BeltRankDto(beltRank.Id, beltRank.RankName, beltRank.TestFees, beltRank.RankPriority));
    }
    public static IQueryable<BeltRankFileDto> ToDto(this IQueryable<BeltRankFile> beltRanks)
    {
        return beltRanks.Select(br=>
        new BeltRankFileDto(br.BeltRank.ToDto(),br.UploadedFileId));
    }
}
