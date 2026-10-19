using KarataClub.Application.Features.UploadedFiles.Dtos;

namespace KarataClub.Application.Features.UploadedFiles.Queries.GetFile;

public sealed class GetFileHandler(IFileStorage fileStorage,ILogger<GetFileHandler> logger) : IRequestHandler<GetFileQuery, Result<DownloadFileDto>>
{
    public async Task<Result<DownloadFileDto>> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
       Result< DownloadFileDto> downloadFileResult = await fileStorage.DownloadAsync(request.FileId,cancellationToken);
        if (downloadFileResult.IsFailure)
        {
            logger.LogError(string.Join(", ", downloadFileResult.Errors));
            return downloadFileResult.Errors;
        }
        return downloadFileResult.Value;
    }
}
