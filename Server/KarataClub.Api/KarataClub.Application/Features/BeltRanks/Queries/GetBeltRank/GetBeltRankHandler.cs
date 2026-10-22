using KarataClub.Application.Features.BeltRanks.Dtos;
using KarataClub.Application.Features.BeltRanks.Mappers;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetBeltRank;

public sealed class GetBeltRankHandler (
    IAppDbContext context,ILogger<GetBeltRankHandler>logger
    ): IRequestHandler<GetBeltRankQuery, Result<BeltRankFileDto?>>
{
    public async Task<Result<BeltRankFileDto?>> Handle(GetBeltRankQuery request, CancellationToken cancellationToken)
    {
        BeltRankFile? beltRank = await context.BeltRankFiles
            .Include(b=>b.BeltRank)
            .Include(b=>b.UploadedFile)
            .FirstOrDefaultAsync(cf=>cf.BeltRankId==request.BeltRankId);
        if(beltRank is null )
        {
            logger.LogError("No Active BeltRank found for id ={BeltRankId}", request.BeltRankId);
            return ApplicationErrors.BeltRankNotFound(request.BeltRankId);
        }
        return beltRank.ToDto()??null;
    }
}
