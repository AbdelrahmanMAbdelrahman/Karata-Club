namespace KarataClub.Domain.Courses.Enrollments;

internal class CourseEnrollmentErrors
{
    internal static Error InvalidPaymentId=Error.Validation("CourseEnrollmentErrors.InvalidPaymentId","Invalid Payment Id");
    internal static Error InvalidMemberId=Error.Validation("CourseEnrollmentErrors.InvalidMemberid","Invalid Member Id");
    internal static Error InvalidCourseId = Error.Validation("CourseEnrollmentErrors.InvalidCourseId","Invalid Course Id");
    internal static Result<CourseEnrollment> InvalidEnrollmentDate;
}
