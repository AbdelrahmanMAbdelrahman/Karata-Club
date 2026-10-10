using KarataClub.Domain.BeltTests;

namespace KarataClub.Domain.Payments;

public sealed class Payment : AuditEntity
{
    public BeltTest BeltTest = default!;
}
