using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Application.Features.BeltRanks.Commands.CreateBeltRanks;

    public sealed record CreateBeltRankCommand(
        string RankName,decimal Fees,Priority Priority,Stream Image,string ContentType,string ImageName)
    :IRequest<Result<BeltRankFileDto>>;

 