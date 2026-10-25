namespace KarataClub.Domain.BeltTests;

public class BeltTest:AuditEntity
{
    public DateTimeOffset TestDate { get; private set; }
    public Guid BeltRankId { get; private set; }
    public DateTimeOffset ReservationDate { get; private set; }
    public Guid InstructorId { get; private set; }
    public Guid MemberId { get; private set; }
    public bool Passed { get; private set; } = false;
    public Guid PaymentId { get; private set; }
    //public PaymentStatus PaymentStatus { get; private set; }
    public string? Notes { get; private set; }
    public Member Member =default!;
    public Instructor Instructor =default!;
    public Payment Payment { get; set; } =default !;
    public BeltRank BeltRank { get; set; } = default!;
    public BeltTest()
    {
        
    }
    public BeltTest(Guid id,DateTimeOffset testDate,Guid beltRankId,
        DateTimeOffset reservationDate,Guid instructorId,
        Guid memeberId,bool passed,Guid paymentId):base(id)
    {
        this.BeltRankId=beltRankId;
        this.TestDate=testDate;
        this.ReservationDate=reservationDate;
        this.InstructorId=instructorId;
        this.MemberId=memeberId;
        this.Passed=passed;
        this.PaymentId=paymentId;
    }

    public static Result<BeltTest> Create(DateTimeOffset testDate, Guid beltRankId,
        DateTimeOffset reservationDate, Guid instructorId,
        Guid memberId, Guid paymentId, bool passed=false) {

        //if (testDate < DateTime.UtcNow) return BeltTestErrors.InvalidTestDate(testDate);
        //if (reservationDate < DateTimeof.UtcNow) return BeltTestErrors.InvalidReservationDate(reservationDate);
        if(testDate<reservationDate)return BeltTestErrors.InvalidTestDate(testDate);
        if (beltRankId == Guid.Empty) return BeltTestErrors.InvalidBeltRankId;
        if (memberId == Guid.Empty) return BeltTestErrors.InvalidMemberId;
        if (paymentId == Guid.Empty) return BeltTestErrors.InvalidPaymentId;

        return new BeltTest(Guid.NewGuid(),testDate,beltRankId,reservationDate,instructorId,memberId,passed,paymentId);
    }

    public Result<Updated> Pass()
    {
        Passed = true;
        return Result.Updated;
    }
    public Result<Updated> Update(DateTime testDate,
        DateTime reservationDate,bool passed,PaymentStatus paymentStatus)
    {
        if (testDate < DateTime.UtcNow) return BeltTestErrors.InvalidTestDate(testDate);
        //if (Enum.IsDefined(PaymentStatus)) return BeltTestErrors.InvalidPaymentStatus;
        if (reservationDate < DateTime.UtcNow) return BeltTestErrors.InvalidReservationDate(reservationDate);

        this.TestDate = testDate;
        //this.PaymentStatus=paymentStatus;
        this.ReservationDate=reservationDate;
        return Result.Updated;
    }

    public Result<Updated> PassTest()
    {
        Passed=true;
        return Result.Updated;
    }
}
