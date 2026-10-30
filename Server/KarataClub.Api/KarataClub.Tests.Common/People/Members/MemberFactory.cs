using KarataClub.Domain.Common.Results;
using KarataClub.Domain.People.Members;

namespace KarataClub.Tests.Common.People.Members;

public static class MemberFactory
{
    public static Result<Member> Create(Guid? personId=null, Guid? lastBeltRankId = null)
    {
        return Member.Create(personId??Guid.NewGuid(),lastBeltRankId??Guid.NewGuid());
    }
}
