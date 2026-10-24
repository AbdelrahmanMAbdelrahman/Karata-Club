
using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Application.Features.BeltRanks.Queries.GetAllowedBeltRank;

public sealed class AllowedBeltRankHandler(
    IAppDbContext context,ILogger<AllowedBeltRankHandler> logger
    ) : IRequestHandler<AllowedBeltRankQuery, Result<BeltRankFileDto>>
{
    public async Task<Result<BeltRankFileDto>> Handle(AllowedBeltRankQuery request, CancellationToken cancellationToken)
    {
        int lastBeltRankPriority = -1;
        Member? member = await context.Members
            .Include(m=>m.LastBeltRank)
            .FirstOrDefaultAsync(m=>m.Id==request.MemberId,cancellationToken);
        if(member is null)
        {
            logger.LogError("NO member found for id = {MemberId}", request.MemberId);
            return ApplicationErrors.MemberNotFound(request.MemberId);
        }
        if(member.LastBeltRank is not null)
        lastBeltRankPriority =(int) member.LastBeltRank.RankPriority;

        BeltRankFile? availableBeltRank = await context.BeltRankFiles
            .Include(b=>b.BeltRank)
            .OrderBy(b=>b.BeltRank.RankPriority)
            .FirstOrDefaultAsync(
            b=>b.BeltRank.RankPriority>(Priority)lastBeltRankPriority,cancellationToken);
        if (availableBeltRank is null) {
            BeltRankFile? beltRank = await context.BeltRankFiles
                .Include(b => b.BeltRank)
                .FirstOrDefaultAsync(cancellationToken);
            if (beltRank is null) {
                logger.LogError("Belt Rank not found");
                return ApplicationErrors.BeltRankNotFound(Guid.Empty);
            }
            return beltRank.ToDto()!;
        }
        return availableBeltRank.ToDto()!;
    }
}
