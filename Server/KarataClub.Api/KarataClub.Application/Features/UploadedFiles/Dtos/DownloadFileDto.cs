namespace KarataClub.Application.Features.UploadedFiles.Dtos;

public sealed record DownloadFileDto(Stream Image,string StoredImageName,string ContentType);
