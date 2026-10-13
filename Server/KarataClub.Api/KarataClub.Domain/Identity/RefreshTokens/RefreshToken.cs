using KarataClub.Domain.Identity.AppUsers;

namespace KarataClub.Domain.Identity.RefreshTokens;

public sealed class RefreshToken:AuditEntity
{
    public string Token { get; private set; } = default!;
    public DateTimeOffset ExpireAt { get; private set; }
    public string UserId { get; private set; } = default!;
    public AppUser User = default!;

    public RefreshToken(){}
    public RefreshToken(Guid id,string userId,string token,DateTimeOffset expireAt):base(id){
    this.UserId = userId;
        this.Token = token;
        this.ExpireAt = expireAt;
    }
    public static Result<RefreshToken> Create(string userId, string token, DateTimeOffset expireAt)
    {
        if (string.IsNullOrWhiteSpace(userId)) return RefreshTokenErrors.InvalidRefreshToken;
        if (string.IsNullOrWhiteSpace(token)) return RefreshTokenErrors.InvalidToken;
        if (expireAt <= DateTime.UtcNow) return RefreshTokenErrors.InvalidExpirationDate;

        return new RefreshToken(Guid.NewGuid(),userId,token,expireAt);
    }
}
