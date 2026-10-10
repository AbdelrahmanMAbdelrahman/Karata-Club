using KarataClub.Domain.BeltTests;
using KarataClub.Domain.Common;
using KarataClub.Domain.People;

namespace KarataClub.Domain.BeltRanks;

public class BeltRank : AuditEntity
{
    public BeltTest BeltTest=default!;
    public ICollection<Person> People=default!;
}
