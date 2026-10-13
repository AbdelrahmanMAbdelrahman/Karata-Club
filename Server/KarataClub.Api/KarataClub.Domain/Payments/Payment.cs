namespace KarataClub.Domain.Payments;

public sealed class Payment : AuditEntity
{
    public Guid MemberId { get;private set; }
    public DateTime PaymentDate { get;private set; }
    public decimal Amount { get;private set; }
    public string? Notes { get; private set; } = default!;
    public Member Member { get; set; } = default!;
    public BeltTest BeltTest = default!;
    public CourseEnrollment CourseEnrollment=default!;
    public Subscription Subscription=default!;

    public Payment(){}
    public Payment(Guid id ,Guid memberId,DateTime paymentDate,decimal amount,string notes):base(id)
    {
      MemberId=memberId;
        PaymentDate=paymentDate;
        Amount=amount;
        Notes=notes;
    }
    public Result<Payment> Create(Guid memberId,DateTime paymentDate,decimal amount,string notes)
    {
        if (memberId == Guid.Empty) return PaymentErrors.InvalidMemberId;
        if (paymentDate != DateTime.UtcNow) return PaymentErrors.InvalidPaymentDate;
        if (amount <= 0 || amount > 10000) return PaymentErrors.InvalidPaymentAmount;

        return new Payment(Guid.NewGuid(), memberId, paymentDate, amount, notes);
    }
}
