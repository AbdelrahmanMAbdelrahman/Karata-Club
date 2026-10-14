namespace KarataClub.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<Result<Success>> SignUpAsync(AppUserDto user,CancellationToken ct);
    Task<Result<AppUserDto>> AuthenticateAsync(string userName,string password,CancellationToken ct);
    Task<Result<bool>> AuthorizeAsync(string userId, string policyName, CancellationToken ct);
    Task<Result<AppUserDto>>GetUserByIdAsync(string userId,CancellationToken ct);
    Task<Result<string>>GetUserNameAsync(string userId,CancellationToken ct);
    Task<Result<bool>>IsInRoleAsync(string userId,string roleName,CancellationToken ct);
}
