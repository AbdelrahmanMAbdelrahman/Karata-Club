using KarataClub.Domain.BeltTests;
using KarataClub.Domain.Common.Results;

namespace KarataClub.Tests.Common.BeltRanks;

public static class BeltTestFactory
{
    public static Result<BeltTest> Create(
        DateTimeOffset? testDate=null,
        Guid? beltRankId = null,
        DateTimeOffset? reservationDate = null,
        Guid? instructorId= null,
        Guid? memberId=null,
        Guid? paymentId = null,
        bool? passed = false
        )
    {
        FakeTimeProvider timeProvider = new FakeTimeProvider();
        return BeltTest.Create(
            testDate??timeProvider.GetUtcNow().AddDays(10),
            beltRankId??Guid.NewGuid(),
            reservationDate??timeProvider.GetUtcNow(),
            instructorId??Guid.NewGuid(),
            memberId??Guid.NewGuid(),
            paymentId??Guid.NewGuid(),
            passed??false
            );
    }

}
