using KarataClub.Domain.BeltTests.BeltRanks;
using KarataClub.Domain.BeltTests.BeltRanks.BeltRanksFiles;
using KarataClub.Domain.UploadedFiles;
using KarataClub.Tests.Common.BeltRanks;

namespace KarataClub.Domain.Tests.BeltRanks;

public  class BeltRankFileTest
{
    [Fact]
    public void CreateBeltRankFile_ShouldPass_ForValidData()
    {
        Guid beltRankId = Guid.NewGuid();
        Guid? uploadedFileId= Guid.NewGuid();
        var beltRankFileRes = BeltRankFileFactory.Create(beltRankId,uploadedFileId);
        Assert.True(beltRankFileRes.IsSuccess);
        BeltRankFile beltRankFile = beltRankFileRes.Value;
        Assert.NotNull(beltRankFile);
        Assert.Equal(beltRankFile.UploadedFileId,uploadedFileId);
        Assert.Equal(beltRankFile.BeltRankId,beltRankId);
    }
    [Fact]
    public void CreateBeltRankFile_ShouldPass_ForValidData2()
    {
        Guid beltRankId = Guid.NewGuid();
        Guid? uploadedFileId= null;
        var beltRankFileRes = BeltRankFileFactory.Create(beltRankId, uploadedFileId);
        Assert.True(beltRankFileRes.IsSuccess);
        BeltRankFile beltRankFile = beltRankFileRes.Value;
        Assert.NotNull(beltRankFile);
        Assert.Equal(beltRankFile.UploadedFileId, uploadedFileId);
        Assert.Equal(beltRankFile.BeltRankId, beltRankId);
    }
    [Fact]
    public void CreateBeltRankFile_ShouldFail_ForInValidData()
    {
        Guid beltRankId = Guid.Empty;
        Guid? uploadedFileId= Guid.NewGuid();
        var beltRankFileRes = BeltRankFileFactory.Create(beltRankId, uploadedFileId);
        Assert.True(beltRankFileRes.IsFailure);
       
    }
    [Fact]
    public void CreateBeltRankFile_ShouldFail_ForInValidData2()
    {
        Guid beltRankId = Guid.NewGuid();
        Guid? uploadedFileId= Guid.Empty;
        var beltRankFileRes = BeltRankFileFactory.Create(beltRankId, uploadedFileId);
        Assert.True(beltRankFileRes.IsFailure);
       
    }

}
