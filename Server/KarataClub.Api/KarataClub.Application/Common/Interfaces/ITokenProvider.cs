using KarataClub.Application.Features.Identity.Dtos;
using System.Security.Claims;

namespace KarataClub.Application.Common.Interfaces
{
    public interface ITokenProvider
    {
        Task<Result<TokenResponse>> GenerateToken(AppUserDto user, CancellationToken ct);
        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string Token);
    }
}
