
namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTest;

public sealed class BeltTestHandler(
    IAppDbContext context,ILogger<BeltTestHandler>logger
    ) : IRequestHandler<BeltTestQuery, Result<BeltTestDto>>
{
    public async Task<Result<BeltTestDto>> Handle(BeltTestQuery request, CancellationToken cancellationToken)
    {
        BeltTest? beltTest = await context.BeltTests
            .AsNoTracking()
            .Include(bt => bt.Member)
              .ThenInclude(m => m.Person)
            .Include(bt => bt.Member)
              .ThenInclude(bt => bt.LastBeltRank)
            .Include(bt => bt.Instructor)
              .ThenInclude(i => i.Person)
            .Include(bt => bt.BeltRank)
            .FirstOrDefaultAsync(bt => bt.Id == request.BeltTestId, cancellationToken);

        if(beltTest is null)
        {
            logger.LogError("No Belt Test found for id = {BeltTestId}", request.BeltTestId);
            return ApplicationErrors.BeltTestNotFound(request.BeltTestId);
        }

        return beltTest.ToDto();
              
    }
}
