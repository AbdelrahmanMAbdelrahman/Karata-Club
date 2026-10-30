using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Courses.CourseFiles;

namespace KarataClub.Tests.Common.Coursesك
{
   public static class CourseFileFactory
    {
        public static Result<CourseFile> Create(Guid? courseId=null, Guid? uploadedFileId = null)
        {
            return CourseFile.Create(
                courseId??Guid.NewGuid(),
                uploadedFileId??Guid.NewGuid ()
                );
        }
    }
}
