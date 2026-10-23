namespace KarataClub.Application.Features.BeltTests.Commands.CreateBeltTests;

public sealed record CreateBeltTestCommand(
    Guid BeltRankId,Guid InstructorId,Guid MemberId,string?Notes):IRequest<Result<BeltTestDto>>;
