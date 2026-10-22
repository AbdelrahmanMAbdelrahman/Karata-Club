namespace KarataClub.Application.Features.BeltRanks.Dtos;

public sealed record class BeltRankFileDto(BeltRankDto BeltRank,Guid? UploadedFileId);
