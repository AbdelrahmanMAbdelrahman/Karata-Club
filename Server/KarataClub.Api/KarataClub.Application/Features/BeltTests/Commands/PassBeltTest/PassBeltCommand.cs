namespace KarataClub.Application.Features.BeltTests.Commands.PassBeltTest;

public sealed record PassBeltCommand(Guid BeltTestId):IRequest<Result<Updated>>
{
}
