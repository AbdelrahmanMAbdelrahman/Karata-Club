using KarataClub.Application.Common.Errors;
using KarataClub.Application.Features.UploadedFiles.Dtos;
using KarataClub.Infrastructure.Settings;

namespace KarataClub.Infrastructure.Services;

public sealed class FileStorage(
    IAppDbContext context, ILogger<FileStorage> logger
    ) : IFileStorage
{
     
    public async Task<Result<DownloadFileDto>> DownloadAsync(Guid Id, CancellationToken ct)
    {
        UploadedFile? file = await context.UploadedFiles.FindAsync(Id,ct);
        if(file is null)
        {
            logger.LogError("No Image found for file with id = {Id}", Id);
            return ApplicationErrors.ImageNotFound(Id);
        }
        string fullPath = Path.Combine(AppSettings.FilesDirectory, file.StoredFileName);
        if (!File.Exists(fullPath)) {
            logger.LogError("Image Source not found");
            return ApplicationErrors.ImageNotFound(Id);
        }
        using Stream fileStream = new FileStream(fullPath,FileMode.Open,FileAccess.Read);
        string contentType = "Image/jpeg";
        return new DownloadFileDto(fileStream,file.StoredFileName,contentType);
    }

    public async Task<Result<UploadFileDto>> UploadAsync(Stream Image, string ImageName, string ContentType, CancellationToken ct)
    {
        if (!Directory.Exists(AppSettings.FilesDirectory))
        {
            Directory.CreateDirectory(AppSettings.FilesDirectory);
        }
        string extn=Path.GetExtension(ImageName);
        string newImageName=Guid.NewGuid().ToString()+extn;
        string imagePath=Path.Combine(AppSettings.FileDirectory,newImageName);
        using Stream stream = new FileStream(imagePath,FileMode.Create);
        await Image.CopyToAsync(stream,ct);
        return new UploadFileDto(ImageName,newImageName,extn,ContentType,Image.Length);
    }
}
