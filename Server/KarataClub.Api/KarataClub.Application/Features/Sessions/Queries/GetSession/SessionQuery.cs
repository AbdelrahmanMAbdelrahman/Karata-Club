using KarataClub.Application.Features.Sessions.Dtos;

namespace KarataClub.Application.Features.Sessions.Queries.GetSession;

public sealed record SessionQuery(Guid SessionId) : ICachedQuery<Result<SessionDto>>
{
    public string CacheKey => $"Session-{SessionId}";

    public string[] Tags => ["Session"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(10);
}
