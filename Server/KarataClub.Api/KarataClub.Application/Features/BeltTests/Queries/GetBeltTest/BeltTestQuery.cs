namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTest;

public sealed record BeltTestQuery(Guid BeltTestId):IRequest<Result<BeltTestDto>>
{

}
