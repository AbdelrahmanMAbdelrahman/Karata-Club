namespace KarataClub.Application.Features.BeltRanks.Mappers;

public static class BeltRankMappers

{
    public static BeltRankDto? ToDto(this BeltRank? beltRank)
    {
        if (beltRank is null) return null;
        return new BeltRankDto();
    }
}
