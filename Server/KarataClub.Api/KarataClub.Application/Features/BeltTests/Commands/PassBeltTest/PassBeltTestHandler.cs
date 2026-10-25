
using System.Reflection.Metadata.Ecma335;

namespace KarataClub.Application.Features.BeltTests.Commands.PassBeltTest;

public sealed class PassBeltTestHandler (
    IAppDbContext context,ILogger<PassBeltTestHandler> logger
    ): IRequestHandler<PassBeltCommand, Result<Updated>>
{
    public async Task<Result<Updated>> Handle(PassBeltCommand request, CancellationToken cancellationToken)
    {
        BeltTest? beltTest =await context.BeltTests
            .Include(b => b.Member)
            .Include(b=>b.BeltRank)
            .FirstOrDefaultAsync(b => b.Id == request.BeltTestId);
        if(beltTest is null)
        {
            logger.LogError("NO belt test found with id : {beltTestId}", request.BeltTestId);
            return ApplicationErrors.BeltTestNotFound(request.BeltTestId);
        }
        if(beltTest.Passed)
        {
            logger.LogWarning("belt test with id : {beltTestId} already passed",request.BeltTestId);
            ApplicationErrors.BeltTestAlreadyPassed(request.BeltTestId);
        }

        Result<Updated> updateBeltTestResult = beltTest.PassTest();
        if (updateBeltTestResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", updateBeltTestResult.Errors));
            return updateBeltTestResult.Errors;
        }
        Result<Updated> updateLastBeltRankResult = beltTest.Member.UpdateLastBeltRank(beltTest.BeltRankId);
        if (updateLastBeltRankResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", updateLastBeltRankResult.Errors));
            return updateLastBeltRankResult.Errors;
        }

        await context.SaveChangesAsync(cancellationToken);
        return Result.Updated;

    }
}
