namespace KarataClub.Application.Features.People.Members.Dtos
{
    public sealed record MemberDto(Guid MemberId,PersonDto person
        ,bool Active,BeltRankDto? BeltRank);
    
    
}
