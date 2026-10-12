
namespace KarataClub.Application.Features.Members.Dtos
{
    public sealed record MemberDto(Guid Id,Guid PersonId,string Name,string Phone,string Email
        ,string EmergencyContactInfo,bool Active,Guid? LastBeltRankId,BeltRankDto? beltRank);
    
    
}
