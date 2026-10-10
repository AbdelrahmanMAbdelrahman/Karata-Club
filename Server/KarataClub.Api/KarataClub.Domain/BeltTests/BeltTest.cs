using KarataClub.Domain.BeltRanks;
using KarataClub.Domain.BeltTests.Enums;
using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Payments;
using KarataClub.Domain.People.Instructors;
using KarataClub.Domain.People.Members;

namespace KarataClub.Domain.BeltTests;

public class BeltTest:AuditEntity
{
    public DateTime TestDate { get; private set; }
    public Guid BeltRankId { get; private set; }
    public DateTime ReservationDate { get; private set; }
    public Guid InstructorId { get; private set; }
    public Guid MemberId { get; private set; }
    public bool Passed { get; private set; } = false;
    public Guid PaymentId { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public string? Notes { get; private set; }
    public ICollection<Member> Members => [];
    public Instructor Instructor =default!;
    public Payment Payment { get; set; } =default !;
    public BeltRank BeltRank { get; set; } = default!;
    public BeltTest()
    {
        
    }
    public BeltTest(Guid id,DateTime testDate,Guid beltRankId,
        DateTime reservationDate,Guid instructorId,
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

    public Result<BeltTest> Create(DateTime testDate, Guid beltRankId,
        DateTime reservationDate, Guid instructorId,
        Guid memeberId, bool passed, Guid paymentId) {

        if (testDate < DateTime.UtcNow) return BeltTestErrors.InvalidTestDate(testDate);
        if (reservationDate < DateTime.UtcNow) return BeltTestErrors.InvalidReservationDate(reservationDate);
        if (BeltRankId == Guid.Empty) return BeltTestErrors.InvalidBeltRankId;
        if (MemberId == Guid.Empty) return BeltTestErrors.InvalidMemberId;
        if (paymentId == Guid.Empty) return BeltTestErrors.InvalidPaymentId;
        if (Enum.IsDefined(PaymentStatus)) return BeltTestErrors.InvalidPaymentStatus;

        return new BeltTest(Guid.NewGuid(),testDate,beltRankId,reservationDate,instructorId,memeberId,passed,paymentId);
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
        if (Enum.IsDefined(PaymentStatus)) return BeltTestErrors.InvalidPaymentStatus;
        if (reservationDate < DateTime.UtcNow) return BeltTestErrors.InvalidReservationDate(reservationDate);

        this.TestDate = testDate;
        this.PaymentStatus=paymentStatus;
        this.ReservationDate=reservationDate;
        return Result.Updated;
    }
}
