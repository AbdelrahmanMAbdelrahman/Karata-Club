using KarataClub.Application.Features.Courses.Dtos;
using KarataClub.Application.Features.Courses.Mappers;
using KarataClub.Application.Features.UploadedFiles.Dtos;

namespace KarataClub.Application.Features.Courses.Commands.CreateCourses;

public sealed class CreateCourseHandler(
    IAppDbContext context,
    ILogger<CreateCourseHandler> logger,
    IFileStorage fileStorage
    ) : IRequestHandler<CreateCourseCommand, Result<CourseFileDto>>
{
    public async Task<Result<CourseFileDto>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        bool conflict = await context.Courses.AnyAsync(c=>c.CourseName==request.CourseName);
        if( conflict)
        {
            logger.LogError("there is alrady a course exist with name = {courseName}", request.CourseName);
            return ApplicationErrors.CourseAlreadyExist(request.CourseName);
        }

        Result<Course> createCourseResult = Course.Create(request.CourseName,request.Fees,request.NumberOfSessions,
            request.TotalHours);
        if (createCourseResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createCourseResult.Errors));
            return createCourseResult.Errors;
        }

        Result<UploadFileDto> uploadedFileResult = await
            fileStorage.UploadAsync(request.Image,request.ImageName,request.ContentType,cancellationToken);
        if (uploadedFileResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", uploadedFileResult.Errors));
            return uploadedFileResult.Errors;
        }
        Result<UploadedFile> createFileResult =
            UploadedFile.Create(request.ImageName,request.ContentType,
            uploadedFileResult.Value.StoredImageName,
            uploadedFileResult.Value.Extension,
            uploadedFileResult.Value.Length);
        if (createFileResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createFileResult.Errors));
            return createFileResult.Errors;
        }
        Result<CourseFile> createCourseFileResult = CourseFile.Create(createCourseResult.Value.Id,
            createFileResult.Value.Id);
        if (createCourseFileResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createCourseFileResult.Errors));
            return createCourseFileResult.Errors;
        }
        CourseFile courseFile = createCourseFileResult.Value;
        courseFile.UploadedFile=createFileResult.Value;
        courseFile.Course=createCourseResult.Value;

        await context.CourseFiles.AddAsync(courseFile,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return courseFile.ToDto();
    }
}
