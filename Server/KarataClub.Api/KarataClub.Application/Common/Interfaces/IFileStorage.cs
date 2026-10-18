using KarataClub.Application.Features.UploadedFiles.Dtos;

namespace KarataClub.Application.Common.Interfaces;

public interface IFileStorage
{
    Task<Result< DownloadFileDto>> DownloadAsync(Guid Id,CancellationToken ct);
    Task<Result< UploadFileDto>> UploadAsync(Stream Image, string ImageName, string ContentType, CancellationToken ct);
}
