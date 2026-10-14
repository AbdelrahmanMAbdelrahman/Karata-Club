namespace KarataClub.Application.Features.People.Members.Dtos
{
    public sealed record MemberDto(Guid Id,PersonDto person
        ,bool Active,BeltRankDto? beltRank);
    
    
}
