namespace KarataClub.Domain.Sessions;

internal class SessionErrors
{
    internal static Error InvalidSessionDate=Error.Validation("SessionErrors.InvalidSessionDate", "Invalid Session Date");
    internal static Error InvalidNumberOfHours=Error.Validation("SessionErrors.InvalidNumberOfHours", "Invalid Number of Hours");
    internal static Error InvalidCourseId = Error.Validation("SessionErrors.InvalidCourseId", "Invalid Course Id");
}
