using KarataClub.Domain.BeltTests.BeltRanks.BeltRanksFiles;
using KarataClub.Domain.Common.Results;
namespace KarataClub.Tests.Common.BeltRanks
{
    public static class BeltRankFileFactory
    {
        public static Result<BeltRankFile> Create(
            Guid? beltRankId=null,
            Guid? uploadedFileId=null)
        {
            return BeltRankFile.Create(
                beltRankId??Guid.NewGuid(),
                uploadedFileId??Guid.NewGuid()
                );
        }
    }
}
