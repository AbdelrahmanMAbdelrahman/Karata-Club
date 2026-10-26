namespace KarataClub.Domain.People.Members.Attendencies;

internal class AttendenceErrors
{
    internal static Error InvalidMemberId=Error.Validation("AttendanceErrors.InvalidMemberId", "Invalid Member Id ");
    internal static Error InvalidSessionId=Error.Validation("AttendanceErrors.InvalidSessionId", "InvalidSessionId");
}
