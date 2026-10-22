using KarataClub.Application.Features.BeltRanks.Dtos;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

public sealed record GetBeltRankQuery(Guid BeltRankId,CancellationToken ct):IRequest<Result<BeltRankFileDto?>>
{
}
