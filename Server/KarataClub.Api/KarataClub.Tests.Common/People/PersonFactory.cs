using KarataClub.Domain.Common.Results;
using KarataClub.Domain.People;

namespace KarataClub.Tests.Common.People;

public static class PersonFactory
{
    public static Result<Person> Create(
        string? name=null, 
        string? email=null,
        string? phone=null, 
        string? address = null)
    {
        return Person.Create(name??"abdelrahman","abdo@gmail.com",phone??"0111",address??"kafr hafez");
    }
}
