

namespace KarataClub.Application.Features.BeltRanks.Queries.GetAllowedBeltRank;

public sealed record AllowedBeltRankQuery(Guid MemberId):IRequest<Result<BeltRankFileDto>>
{
}
