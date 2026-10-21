using KarataClub.Application.Features.Courses.Dtos;

namespace KarataClub.Application.Features.Courses.Mappers;

public static class CourseMappers
{
    public static CourseDto ToDto(this Course course)
    {
        return new CourseDto(course.Id,course.CourseName,course.Fees,course.Active,course.TotalHours,course.NumberOfSessions);
    }
    public static CourseFileDto ToDto(this CourseFile courseFile) {
        return new CourseFileDto(courseFile.Id,courseFile.Course.ToDto(),courseFile.UploadedFileId);
    }
    public static IQueryable<CourseFileDto> ToDto(this IQueryable<CourseFile> courseFiles) {
        return courseFiles.Select(
            cf=>
            new CourseFileDto(cf.Id,cf.Course.ToDto(),cf.UploadedFileId)
            );
    }
}
