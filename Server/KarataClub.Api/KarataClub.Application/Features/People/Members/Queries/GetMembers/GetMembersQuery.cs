namespace KarataClub.Application.Features.People.Members.Queries.GetMembers;

public sealed record GetMembersQuery(
    int PageNumber = 1, int PageSize = 10,
    string SortColumn = "Name", string SortDirection = "Desc",
    string? Name = null, string? RankName = null, bool? Active = true
    ) : ICachedQuery<Result<PaginatedList<MemberDto>>>
{
    public string CacheKey =>
        $"p:{PageNumber}-pa:{PageSize}-" +
        $"sc:{SortColumn}-sd:{SortDirection}-"+
        $"n:{Name}-rn:{RankName}-a:{Active}";

    public string[] Tags => ["Member"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
