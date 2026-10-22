namespace KarataClub.Application.Features.Courses.Queries.GetCourse;

public sealed class GetCourseHandler (
    IAppDbContext context,ILogger<GetCourseHandler>logger
    ): IRequestHandler<GetCourseQuery, Result<CourseFileDto>>
{
    public async Task<Result<CourseFileDto>> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        CourseFile? course = await context.CourseFiles.
            Include(cf => cf.Course)
            .Include(cf => cf.UploadedFile)
            .FirstOrDefaultAsync(cf=>cf.Id==request.CourseFileId);
        if(course is null ||!course.Course.Active)
        {
            logger.LogError("No Active Course found for id ={courseFileId}", request.CourseFileId);
            return ApplicationErrors.CourseNotFound(request.CourseFileId);
        }
        return course.ToDto();
    }
}
