using KarataClub.Domain.BeltTests.BeltRanks;
using KarataClub.Domain.BeltTests.BeltRanks.Enums;
using KarataClub.Tests.Common.BeltRanks;

namespace KarataClub.Domain.Tests.BeltRanks;

public  class BeltRankTest
{
    [Fact]
    public void CreateBeltRank_ShouldPass_ForValidData()
    {
        string rankName = "white";
        decimal testFees = 100;
        Priority rankPriority = Priority.White;
        var beltRankRes = BeltRankFactory.Create(rankName,testFees,rankPriority);
        Assert.True(beltRankRes.IsSuccess);
        BeltRank beltRank = beltRankRes.Value;
        Assert.True(beltRank != null);
        Assert.Equal(beltRank.RankName,rankName);
        Assert.Equal(beltRank.TestFees,testFees);
        Assert.Equal(beltRank.RankPriority,rankPriority);
    }
    [Theory]
    [InlineData("",100,Priority.White)]
    [InlineData("White",0,Priority.White)]
    [InlineData("White",-1,Priority.White)]
    public void CreateBeltRank_ShouldFail_ForInvalidData(string rankName,decimal fees,Priority priority)
    {
        var beltRankRes = BeltRankFactory.Create(rankName, fees, priority);
        Assert.True(beltRankRes.IsFailure);
    }
}
