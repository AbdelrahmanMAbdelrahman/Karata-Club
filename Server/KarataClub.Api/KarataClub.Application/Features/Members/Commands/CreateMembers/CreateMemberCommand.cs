namespace KarataClub.Application.Features.Members.Commands.CreateMembers;

public sealed  record CreateMemberCommand(
    string Name, string Phone, string Email, string Address,string EmergencyContactInfo)
    :IRequest<Result<MemberDto>>;
