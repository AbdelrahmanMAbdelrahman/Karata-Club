namespace KarataClub.Domain.Courses;

internal class CourseErrors
{
    internal static Error InvalidCourseTotalHours=Error.Validation("CourseErrors.InvalidCourseTotalHours", "Invalid Course Total Hours");
    internal static Error InvalidCourseSessions=Error.Validation("CourseErrors.InvalidCourseSessions", "Invalid Course Sessions");
    internal static Error InvalidCourseName=Error.Validation("CourseErrors.InvalidCourseName", "Invalid Course Name");
    internal static Error InvalidCourseFees=Error.Validation("CourseErrors.InvalidCourseFees", "Invalid Course Fees");
}
