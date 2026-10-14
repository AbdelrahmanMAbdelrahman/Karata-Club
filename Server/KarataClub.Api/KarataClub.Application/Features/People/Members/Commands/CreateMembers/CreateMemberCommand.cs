using KarataClub.Application.Features.People.Members.Dtos;

namespace KarataClub.Application.Features.People.Members.Commands.CreateMembers;

public sealed  record CreateMemberCommand(
    string Name, string Phone, string Email, string Address)
    :IRequest<Result<MemberDto>>;
