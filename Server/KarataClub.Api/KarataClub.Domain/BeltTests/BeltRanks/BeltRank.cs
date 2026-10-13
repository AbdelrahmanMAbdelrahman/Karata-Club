using KarataClub.Domain.BeltTests.BeltRanks.BeltRanksFiles;
using KarataClub.Domain.BeltTests.BeltRanks.Enums;

namespace KarataClub.Domain.BeltTests.BeltRanks;

public class BeltRank : AuditEntity
{
    public string RankName { get; private set; } = default!;
    public decimal TestFees { get; private set; }
    
    public Priority RankPriority { get; private set; }
    public ICollection<BeltTest> BeltTests=default!;
    public ICollection<Person> People=default!;
    public ICollection<BeltRankFile> BeltRankFiles=default!;
     
    public BeltRank(){}
    public BeltRank(Guid id,string rankName,decimal testFees,Priority rankPriority):base(id){
    RankName = rankName;
        RankPriority = rankPriority;
        TestFees = testFees;
    }
    public Result<BeltRank> Create(string rankName, decimal testFees, Priority rankPriority)
    {
        if (string.IsNullOrEmpty(rankName)) return BeltRankErrors.InvalidRankName;
        if (TestFees < 0 || TestFees > 10000m) return BeltRankErrors.InvalidTestFees;
        if (!Enum.IsDefined(rankPriority)) return BeltRankErrors.InvalidRankPriority;

        return new BeltRank(Guid.NewGuid(),rankName,testFees,rankPriority);
    }
}
