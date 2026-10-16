namespace KarataClub.Application.Features.People.Members.Mappers;

public static class MemberMapers
{
    public static MemberDto ToDto(this Member member)
    {
        return new MemberDto(
            member.Id,
           member.Person.ToDto(),
           member.Active,
             member.LastBeltRank?.ToDto());
    }

    public static PersonDto ToDto(this Person person) {
        return new PersonDto(person.Id, person.Name, person.Phone,person.Email ?? "N/A",person.Address);
    }

    public static IQueryable<MemberDto> ToDto(this IQueryable<Member> members)
    {
        return members.Select(member =>
        new MemberDto(member.Id,  member.Person.ToDto(),member.Active,
        member.LastBeltRank.ToDto()));

    }
}
