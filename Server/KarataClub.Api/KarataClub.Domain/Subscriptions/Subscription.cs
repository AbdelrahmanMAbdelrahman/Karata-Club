namespace KarataClub.Domain.Subscriptions;

public class Subscription:AuditEntity
{
    public Guid PaymentId { get; private set; }
    public Guid MemberId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal Fees { get; private set; }
    public Payment Payment { get; set; } = default!;
    public Member Member = default!;

    public Subscription() { }
    public Subscription(Guid id, Guid paymentId, Guid memberId, DateTime startDate, DateTime endDate, decimal fees) : base(id)
    {
        PaymentId = paymentId;
        MemberId = memberId;
        StartDate = startDate;
        EndDate = endDate;
        Fees = fees;

    }
    public static Result<Subscription> Create(Guid paymentId, Guid memberId, DateTime startDate, DateTime endDate, decimal fees)
    {
        if (paymentId == Guid.Empty) return SubscriptionErrors.InvalidPaymentId;
        if (memberId == Guid.Empty) return SubscriptionErrors.InvalidMemberId;
        if (startDate > endDate) return SubscriptionErrors.InvalidStartDate;
        if (startDate < DateTime.UtcNow) return SubscriptionErrors.InvalidStartDate;
        if (endDate <= DateTime.UtcNow) return SubscriptionErrors.InvalidEndDate;
        if (fees < 0 || fees > 10000) return SubscriptionErrors.InvalidSubscriptionFees;

        return new Subscription(Guid.NewGuid(), paymentId, memberId, startDate, endDate, fees);
    }
}
