namespace KarataClub.Domain.Attendencies;

internal class AttendanceErrors
{
    internal static Error InvalidMemberId=Error.Validation("AttendanceErrors.InvalidMemberId", "Invalid Member Id ");
    internal static Error InvalidSessionId=Error.Validation("AttendanceErrors.InvalidSessionId", "InvalidSessionId");
}
