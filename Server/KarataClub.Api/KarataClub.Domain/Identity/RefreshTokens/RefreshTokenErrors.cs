
namespace KarataClub.Domain.Identity.RefreshTokens;

internal class RefreshTokenErrors
{
    internal static Error InvalidExpirationDate=Error.Validation("RefreshTokenErrors.InvalidExpirationDate", "Invalid Expiration Date");
    internal static Error InvalidToken=Error.Validation("RefreshTokenErrors.InvalidToken", "Invalid Token");
    internal static Error InvalidRefreshToken=Error.Validation("RefreshTokenErrors.InvalidRefreshToken", "Invalid Refresh Token");
}
