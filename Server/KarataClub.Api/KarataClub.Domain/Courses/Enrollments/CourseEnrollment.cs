namespace KarataClub.Domain.Courses.Enrollments;

public sealed class CourseEnrollment:AuditEntity
{
    public Guid CourseId { get;private set; }
    public Guid MemberId { get; private set; }
    public Guid PaymentId {  get; private set; }
    public Course Course { get; set; } = default!;
    public Payment Payment { get; set; } = default!;
    public Member Member=default!;

    public CourseEnrollment(){}
    public CourseEnrollment(Guid id,Guid courseId,Guid memberId,Guid paymentId):base(id){
    CourseId = courseId;
        MemberId = memberId;
        PaymentId = paymentId;
    }
    public static Result<CourseEnrollment> Create(Guid courseId, Guid memberId, Guid paymentId) {
        if (courseId == Guid.Empty) return CourseEnrollmentErrors.InvalidCourseId;
        if (memberId == Guid.Empty) return CourseEnrollmentErrors.InvalidMemberId;
        if (paymentId == Guid.Empty) return CourseEnrollmentErrors.InvalidPaymentId;

        return new CourseEnrollment(Guid.NewGuid(),courseId,memberId,paymentId);
    }
}

