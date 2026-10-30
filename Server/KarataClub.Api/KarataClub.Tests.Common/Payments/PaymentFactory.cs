using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Payments;

namespace KarataClub.Tests.Common.Payments;

public  static class PaymentFactory
{
    public static Result<Payment> Create(
        Guid? memberId = null,
        DateTimeOffset? paymentDate = null,
        decimal? amount=null,
        string? notes=null)
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        return Payment.Create(
            memberId??Guid.NewGuid(),
            paymentDate??fakeTimeProvider.GetUtcNow(),
            amount??1,
            notes??"notes"
            );
    }
}
