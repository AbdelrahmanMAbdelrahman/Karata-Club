namespace KarataClub.Application.Features.People.Members.Dtos;

public sealed record PersonDto(Guid PersonId, string Name, string Phone, string Email,string Address)
{

}
