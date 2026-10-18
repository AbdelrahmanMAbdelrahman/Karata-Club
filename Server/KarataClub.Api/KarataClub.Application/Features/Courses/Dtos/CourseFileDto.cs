namespace KarataClub.Application.Features.Courses.Dtos;

public sealed record CourseFileDto(Guid CourseFileId,CourseDto Course,Guid? UploadedFileId);
