

namespace KarataClub.Application.Features.People.Members.Commands.UpdateMembers;

public sealed record UpdateMemberCommand
    (Guid MemberId,string Name, string Phone, string Email, string Address)
    :IRequest<Result<Updated>>
{
}
