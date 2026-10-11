

namespace KarataClub.Domain.UploadedFiles
{
    internal class UploadedFileErrors
    {
        internal static Error InvalidFileName=Error.Validation("UplodaedFileErrors.InvalidFileName", "Invalid File Name");
        internal static Error InvalidExtension=Error.Validation("UplodaedFileErrors.InvalidExtension", "Invalid Extension");
        internal static Error InvalidStoredFileName=Error.Validation("UplodaedFileErrors.InvalidStoredFileName", "Invalid Stored File Name");
        internal static Error InvalidContentType=Error.Validation("UplodaedFileErrors.InvalidContentType", "Invalid Content Type");
        internal static Error InvalidSize = Error.Validation("UplodaedFileErrors.InvalidSize", "Invalid Size");
    }
}
