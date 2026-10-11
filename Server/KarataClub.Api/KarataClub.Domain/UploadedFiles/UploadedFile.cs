namespace KarataClub.Domain.UploadedFiles;

public sealed class UploadedFile:AuditEntity
{
    public string FileName { get; private set; } = default!;
    public string ContentType { get; private set; } = default!;
    public string StoredFileName { get; private set; } = default!;
    public string Extension { get; private set; } = default!;
    public decimal Size { get; private set; }
    public CourseFile CourseFile = default!;
    public BeltRank BeltRank= default!;

    private UploadedFile()
    {
        
    }
    private UploadedFile(Guid id,string fileName,string contentType,string storedFileName,string extension, decimal size):base(id)
    {
        FileName = fileName;
        ContentType = contentType;
        StoredFileName = storedFileName;
        Extension = extension;
        Size = size;

    }
    public Result<UploadedFile> Create(string fileName, string contentType, string storedFileName, string extension, decimal size)
    {
        if (string.IsNullOrWhiteSpace(fileName)) return UploadedFileErrors.InvalidFileName;
        if (string.IsNullOrWhiteSpace(contentType)) return UploadedFileErrors.InvalidContentType;
        if (string.IsNullOrWhiteSpace(storedFileName)) return UploadedFileErrors.InvalidStoredFileName;
        if (string.IsNullOrWhiteSpace(extension)) return UploadedFileErrors.InvalidExtension;
        if (size<=0 ||size>10*1024*1024) return UploadedFileErrors.InvalidSize;

        return new UploadedFile(Guid.NewGuid(),fileName,contentType,storedFileName,extension,size);
    }

}
