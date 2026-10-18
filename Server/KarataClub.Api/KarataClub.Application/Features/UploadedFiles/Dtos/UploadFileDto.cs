namespace KarataClub.Application.Features.UploadedFiles.Dtos;

public sealed record UploadFileDto(
    string ImageName,string StoredImageName,string Extension,string ContentType,long Length);
