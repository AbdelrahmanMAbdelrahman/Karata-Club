using KarataClub.Domain.BeltTests.BeltRanks;
using KarataClub.Domain.Common;

namespace KarataClub.Domain.BeltTests.BeltRanks.BeltRanksFiles;

public sealed class BeltRankFile:AuditEntity
{
    public Guid BeltRankId { get;private set; }
    public Guid UploadedFileId { get; private set; }
    public BeltRank BeltRank = default!;
    public UploadedFile UploadedFile = default!;
    public BeltRankFile()
    {
        
    }
    public BeltRankFile(Guid id,Guid beltRankId,Guid uploadedFileId):base(id)
    {
        BeltRankId = beltRankId;
        UploadedFileId = uploadedFileId;
    }
    public Result<BeltRankFile> Create(Guid beltRankId, Guid uploadedFileId) {
        if (beltRankId == Guid.Empty) return BeltRankFilesErrors.InvalidBeltRankId;
        if (uploadedFileId == Guid.Empty) return BeltRankFilesErrors.InvalidUploadedFileId;

        return new BeltRankFile(Guid.NewGuid(),beltRankId,uploadedFileId);
    }
}
