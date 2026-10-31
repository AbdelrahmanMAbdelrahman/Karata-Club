using KarataClub.Domain.Identity.RefreshTokens;
using KarataClub.Tests.Common;
using KarataClub.Tests.Common.Identity;

namespace KarataClub.Domain.Tests.IdentityTests;

public class RefreshTokenTests
{
    [Fact]
    public void CreateRefreshToken_ShouldPass_ForValidData()
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        string userId = Guid.NewGuid().ToString();
        string token = Guid.NewGuid().ToString();
        DateTimeOffset expireAt= fakeTimeProvider.GetUtcNow().AddDays(1);
        var refTokenRes = RefreshTokenFactory.Create(userId,token,expireAt);
        Assert.True(refTokenRes.IsSuccess);
        RefreshToken refreshToken = refTokenRes.Value;
        Assert.NotNull(refreshToken);
        Assert.Equal(userId, refreshToken.UserId);
        Assert.Equal(token, refreshToken.Token);
        Assert.Equal(expireAt, refreshToken.ExpireAt);
    }
    [Fact]
    public void CreateRefreshToken_ShouldFail_ForInValidUserId()
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        string userId = Guid.Empty.ToString();
        string token = Guid.NewGuid().ToString();
        DateTimeOffset expireAt= fakeTimeProvider.GetUtcNow().AddDays(1);
        var refTokenRes = RefreshTokenFactory.Create(userId,token,expireAt);
        Assert.True(refTokenRes.IsFailure);
      
    }
    [Fact]
    public void CreateRefreshToken_ShouldFail_ForInValidToken()
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        string userId = Guid.NewGuid().ToString();
        string token = "";
        DateTimeOffset expireAt=fakeTimeProvider.GetUtcNow().AddDays(1);
        var refTokenRes = RefreshTokenFactory.Create(userId,token,expireAt);
        Assert.True(refTokenRes.IsFailure);
      
    }
    [Fact]
    public void CreateRefreshToken_ShouldFail_ForInValidExpireDate()
    {
        FakeTimeProvider fakeTimeProvider = new FakeTimeProvider();
        string userId = Guid.NewGuid().ToString();
        string token = Guid.NewGuid().ToString();
        DateTimeOffset expireAt= fakeTimeProvider.GetUtcNow();
        var refTokenRes = RefreshTokenFactory.Create(userId,token,expireAt);
        Assert.True(refTokenRes.IsFailure);
      
    }
 
}
