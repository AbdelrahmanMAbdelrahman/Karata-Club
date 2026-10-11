namespace KarataClub.Domain.BeltRanks;

internal class BeltRankErrors
{
    internal static Error InvalidTestFees=Error.Validation("BeltRankErrors.InvalidTestFees", "Invalid Test Fees");
    internal static Error InvalidRankName=Error.Validation("BeltRankErrors.InvalidRankName", "Invalid Rank Name");
    internal static Error InvalidRankPriority=Error.Validation("BeltRankErrors.InvalidRankPriority", "Invalid Rank Priority");
}
