using KarataClub.Application.Features.UploadedFiles.Dtos;
using Microsoft.Extensions.Caching.Hybrid;

namespace KarataClub.Application.Features.BeltRanks.Commands.CreateBeltRanks;

public sealed class CreateBeltRankHandler(
    IAppDbContext context,
    ILogger<CreateBeltRankHandler> logger,
    HybridCache hybridCache,
    IFileStorage fileStorage
    ) : IRequestHandler<CreateBeltRankCommand, Result<BeltRankFileDto>>
{
    public async Task<Result<BeltRankFileDto>> Handle(CreateBeltRankCommand request, CancellationToken cancellationToken)
    {
        bool conflict = await context.BeltRanks.AnyAsync(c=>c.RankName==request.RankName);
        if( conflict)
        {
            logger.LogError("there is alrady a BeltRank exist with name = {RankName}", request.RankName);
            return ApplicationErrors.BeltRankAlreadyExist(request.RankName);
        }

        Result<BeltRank> createBeltRankResult = BeltRank
            .Create(request.RankName,request.Fees,request.Priority);
        if (createBeltRankResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createBeltRankResult.Errors));
            return createBeltRankResult.Errors;
        }
        BeltRank beltRank = createBeltRankResult.Value!;

        Result<UploadFileDto>? uploadedFileResult = null;
        Result<UploadedFile>? createFileResult = null;
        if (request.Image is not null)
        {
            uploadedFileResult = await
                fileStorage.UploadAsync(request.Image, request.ImageName, request.ContentType, cancellationToken);
            if (uploadedFileResult.IsFailure)
            {
                logger.LogError(string.Join(" - ", uploadedFileResult.Errors));
                return uploadedFileResult.Errors;
            }
            createFileResult =
                UploadedFile.Create(request.ImageName, request.ContentType,
                uploadedFileResult.Value.StoredImageName,
                uploadedFileResult.Value.Extension,
                uploadedFileResult.Value.Length);
            if (createFileResult.IsFailure)
            {
                logger.LogError(string.Join(" - ", createFileResult.Errors));
                return createFileResult.Errors;
            }
        }
        Result<BeltRankFile> createBeltRankFileResult = BeltRankFile.Create(createBeltRankResult.Value.Id,
            createFileResult != null ? createFileResult.Value.Id : null);
        if (createBeltRankFileResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createBeltRankFileResult.Errors));
            return createBeltRankFileResult.Errors;
        }
        BeltRankFile beltRankFile = createBeltRankFileResult.Value;
        beltRankFile.BeltRank = beltRank;
        beltRankFile.UploadedFile = createFileResult!.Value??null;
       

        await context.BeltRankFiles.AddAsync(beltRankFile,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await hybridCache.RemoveByTagAsync("BeltRank",cancellationToken);
        return beltRankFile.ToDto()!;
    }
}
