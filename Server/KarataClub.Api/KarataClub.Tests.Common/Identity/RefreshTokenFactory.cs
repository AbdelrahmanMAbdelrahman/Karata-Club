using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Identity.RefreshTokens;

namespace KarataClub.Tests.Common.Identity;

public static class RefreshTokenFactory
{
    public static Result<RefreshToken> Create(
        string? userId=null,
        string? token=null,
        DateTimeOffset? expireAt=null)
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        return RefreshToken.Create(
            userId??Guid.NewGuid().ToString(),
            token??Guid.NewGuid().ToString(),
            expireAt??fakeTimeProvider.GetUtcNow()
            );
    }
}
