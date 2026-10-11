namespace KarataClub.Domain.CourseFiles;

internal class CourseFileErrors
{
    internal static Error InvalidUploadedFileId=Error.Validation("CourseFileErrors.InvalidUploadedFileId", "Invalid Uploaded File Id");
    internal static Error InvalidCourseId = Error.Validation("CourseFileErrors.InvalidCourseId", "Invalid Course Id");
}
