using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Api.Requests.BeltRanks;

public sealed record BeltRankReq(string RankName, decimal TestFees, Priority Priority, IFormFile? Image);
