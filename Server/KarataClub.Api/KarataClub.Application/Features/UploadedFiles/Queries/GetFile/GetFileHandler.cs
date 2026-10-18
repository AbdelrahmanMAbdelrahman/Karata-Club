using KarataClub.Application.Features.UploadedFiles.Dtos;

namespace KarataClub.Application.Features.UploadedFiles.Queries.GetFile;

public sealed class GetFileHandler(IFileStorage fileStorage,ILogger<GetFileHandler> logger) : IRequestHandler<GetFileQuery, Result<DownloadFileDto>>
{
    public Task<Result<DownloadFileDto>> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
