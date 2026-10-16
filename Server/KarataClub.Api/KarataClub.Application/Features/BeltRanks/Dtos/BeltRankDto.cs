using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Application.Features.BeltRanks.Dtos;

public sealed record BeltRankDto(Guid Id,string RankName,Priority Priority);
