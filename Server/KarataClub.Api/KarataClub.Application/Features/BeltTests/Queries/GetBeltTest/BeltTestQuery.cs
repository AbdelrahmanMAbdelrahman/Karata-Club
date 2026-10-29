namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTest;

public sealed record BeltTestQuery(Guid BeltTestId):ICachedQuery<Result<BeltTestDto>>
{
    public string CacheKey => $"BeltTest-{BeltTestId}";
    public string[] Tags => ["BeltTest"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);

}
