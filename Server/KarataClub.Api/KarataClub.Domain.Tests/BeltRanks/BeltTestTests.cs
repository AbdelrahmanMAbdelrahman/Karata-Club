using KarataClub.Domain.BeltTests;
using KarataClub.Tests.Common;
using KarataClub.Tests.Common.BeltRanks;

namespace KarataClub.Domain.Tests.BeltRanks;

public class BeltTestTests
{
    [Fact]
    public void CreateBeltTest_ShouldPass_ForValidData()
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        DateTimeOffset testDate = fakeTimeProvider.GetUtcNow().AddDays(10);
        Guid beltRankId = Guid.NewGuid();
        DateTimeOffset reservationDate = fakeTimeProvider.GetUtcNow();
        Guid instructorId = Guid.NewGuid();
        Guid memberId = Guid.NewGuid();
        Guid paymentId = Guid.NewGuid();
        bool passed = false;
        var beltTestRes = BeltTestFactory.Create(
            testDate,beltRankId,reservationDate,instructorId,memberId,paymentId,passed);
        Assert.True(beltTestRes.IsSuccess);
        BeltTest beltTest = beltTestRes.Value;
        Assert.NotNull(beltTest);
        Assert.Equal(beltTest.TestDate,testDate);
        Assert.Equal(beltTest.ReservationDate,reservationDate);
        Assert.Equal(beltTest.BeltRankId,beltRankId);
        Assert.Equal(beltTest.InstructorId,instructorId);
        Assert.Equal(beltTest.MemberId,memberId);
        Assert.Equal(beltTest.PaymentId,paymentId);
        Assert.Equal(beltTest.Passed,passed);
    }
    [Fact]
    public void CreateBeltTest_ShouldFail_ForInValidDate()
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        DateTimeOffset testDate = fakeTimeProvider.GetUtcNow();
        Guid beltRankId = Guid.NewGuid();
        DateTimeOffset reservationDate = fakeTimeProvider.GetUtcNow();
        Guid instructorId = Guid.NewGuid();
        Guid memberId = Guid.NewGuid();
        Guid paymentId = Guid.NewGuid();
        bool passed = false;
        var beltTestRes = BeltTestFactory.Create(
            testDate, beltRankId, reservationDate, instructorId, memberId, paymentId, passed);
        Assert.True(beltTestRes.IsFailure); 
    }
        [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000", "04EBC589-625F-4337-A858-5496EEBA2E3A", "59B720D0-251C-46C2-BE19-67FB15416663", "82860007-A4C9-43D5-B665-7E853F90612A")]
    [InlineData("0E7D897D-17ED-4236-8B14-0F0BE772521D", "00000000-0000-0000-0000-000000000000", "59B720D0-251C-46C2-BE19-67FB15416663", "82860007-A4C9-43D5-B665-7E853F90612A")]
    [InlineData("0E7D897D-17ED-4236-8B14-0F0BE772521D", "04EBC589-625F-4337-A858-5496EEBA2E3A", "00000000-0000-0000-0000-000000000000", "82860007-A4C9-43D5-B665-7E853F90612A")]
    [InlineData("0E7D897D-17ED-4236-8B14-0F0BE772521D", "04EBC589-625F-4337-A858-5496EEBA2E3A", "59B720D0-251C-46C2-BE19-67FB15416663", "00000000-0000-0000-0000-000000000000")]
    public void CreatebeltTest_shouldFail_ForInvalidData(string beltRankId,string instructorId,string memberId,string paymentId)
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        DateTimeOffset testDate = fakeTimeProvider.GetUtcNow().AddDays(10);
        DateTimeOffset reservationDate = fakeTimeProvider.GetUtcNow();
        var beltTestRes = BeltTestFactory.Create(
            testDate,
            Guid.Parse(beltRankId),
            reservationDate,
            Guid.Parse(instructorId),
            Guid.Parse(memberId),
            Guid.Parse(paymentId)
            );
        Assert.True(beltTestRes.IsFailure);
    }
}
