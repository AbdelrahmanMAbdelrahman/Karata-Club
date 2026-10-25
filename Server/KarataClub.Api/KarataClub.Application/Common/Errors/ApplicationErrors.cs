namespace KarataClub.Application.Common.Errors;

public static class ApplicationErrors
{
    internal static Result<SubscriptionDto> SubscriptionAlreadyExist =>
        Error.Conlict("SubscriptionErrors.SubscriptionAlreadyExist", "Subscription Already Exist");

    public static Error InCorrectUserNameOrPassword => Error.BadRequest("Identity.BadRequest", "Incorrect username or passwrod");
    public static Error MemberAlreadyExist => Error.BadRequest("Identity.MemberAlreadyExist", "Member Already Exist");
    internal static Error InstructorAlreadyExist => Error.Conlict("InstructorErrors.InstructorAlreadyExist", "Instructor already exist");

    public static Error BeltTestAlreadyExist { get; internal set; }

    public static Error UserNotFound(string email) => Error.NotFound("AuthErrors.UserNotFound", $"No user found for email = {email}");

    public static Error MemberNotFound(Guid memberId) => Error.NotFound("MemberError.MemberNotFound", $"no member found for id = {memberId}");

    internal static Error InstructorNotFound(Guid instructorId)
   => Error.NotFound("SubscriptionError.NotFound", $"No Instructor found for id = {instructorId}");

    internal static Error SubscriptionNotFound(Guid subscriptionId)
    => Error.NotFound("SubscriptionError.NotFound", $"No Subscription found for id ={subscriptionId}");

    public static Error ImageNotFound(Guid id) => Error.NotFound("ImageErrors.ImageNotFound", "ImageNotFound");

    internal static Error CourseAlreadyExist(string courseName) => Error.Conlict("CourseErrors.CourseAlreadyExist", "CourseAlreadyExist");

    internal static Error CourseNotFound(Guid courseFileId) => Error.NotFound("CourseErrors.CourseNotFound", "CourseNotFound");

    internal static Error BeltRankAlreadyExist(string rankName) =>
        Error.Conlict("BelkRankErrors.BeltRankAlreadyExist", "Belt Rank Already Exist");

    internal static Error BeltRankNotFound(Guid beltRankId) => Error.NotFound("BeltRankErrors.BeltRankNotFound", "Belt Rank Not Found");

    internal static Error MemberHasAlreadyEnrollment(Guid courseId, Guid memberId)
  => Error.Conlict("MemberErrors.Conflict", $"member with id = {memberId} already has enrolled in course with id {courseId}");

    internal static Error EnrollmentNotFound(Guid enrollmentId)
    => Error.NotFound("Enrollment.NotFound", $"no enrollment found for id {enrollmentId}");

    internal static Error MustHasSubscription(Guid memberId)
    => Error.Validation("Subscription.HasNoSubscription", $"no active subscription found for member with id {memberId}");

    internal static Error BeltTestNotFound(Guid beltTestId)
    => Error.NotFound("BeltTest.NotFound", $"No Belt Test found for id {beltTestId}");

    internal static void BeltTestAlreadyPassed(Guid beltTestId)
    {
        throw new NotImplementedException();
    }
}
