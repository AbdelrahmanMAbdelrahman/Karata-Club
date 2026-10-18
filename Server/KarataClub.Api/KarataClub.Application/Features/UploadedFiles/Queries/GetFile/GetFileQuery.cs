using KarataClub.Application.Features.UploadedFiles.Dtos;
namespace KarataClub.Application.Features.UploadedFiles.Queries.GetFile;

public sealed record GetFileQuery(Guid FileId):IRequest<Result<DownloadFileDto>>
{
}
