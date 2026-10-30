using KarataClub.Domain.Common.Results;
using KarataClub.Domain.UploadedFiles;

namespace KarataClub.Tests.Common.UploadedFiles;

public static class UploadedFileFactory
{
    public static Result<UploadedFile> Create(
        string? fileName=null,
        string? contentType=null,
        string? storedFileName=null,
        string? extension=null,
        decimal? size=null
        )
    {
        return UploadedFile.Create(
            fileName ?? "image.jpeg",
            contentType ?? "jpeg",
            storedFileName ?? Guid.NewGuid().ToString() + "jpeg",
            extension ??"jpeg",
            size ?? 2*1024*1024
            );
    }
}
