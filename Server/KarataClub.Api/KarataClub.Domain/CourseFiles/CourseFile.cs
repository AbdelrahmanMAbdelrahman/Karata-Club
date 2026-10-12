namespace KarataClub.Domain.CourseFiles;

public class CourseFile:AuditEntity
{
    public Guid CourseId { get;private set; }
    public Guid UploadedFileId { get;private set; }
    public Course Course { get; set; } = default!;
    public UploadedFile UploadedFile { get; set; }= default!;

    public CourseFile(){}
    public CourseFile(Guid id,Guid courseId,Guid uploadedFileId):base(id){
    CourseId=courseId;
        UploadedFileId=uploadedFileId;
    }
    public Result<CourseFile> Create(Guid courseId, Guid uploadedFileId)
    {
        if (CourseId == Guid.Empty) return CourseFileErrors.InvalidCourseId;
        if (uploadedFileId == Guid.Empty) return CourseFileErrors.InvalidUploadedFileId;
        return new CourseFile(Guid.NewGuid(),courseId,uploadedFileId);
    }
}
