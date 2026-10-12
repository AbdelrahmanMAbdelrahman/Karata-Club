namespace KarataClub.Application.Features.Members.Mappers;

public static class MemberMapers
{
    public static MemberDto ToDto(this Member member)
    {
        return new MemberDto(
            member.Id,member.PersonId,member.Person.Name,member.Person.Phone, member.Person.Email??"N/A",
            member.EmergencyContactInfo, member.Active,member.LastBeltRankId,
             member.LastBeltRank?.ToDto());
    }
}
