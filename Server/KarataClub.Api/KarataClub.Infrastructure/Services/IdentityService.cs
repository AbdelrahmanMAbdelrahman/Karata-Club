
using KarataClub.Application.Common.Errors;
using System.Runtime.Serialization;

namespace KarataClub.Infrastructure.Services;

public class IdentityService(
    IAppDbContext context,ILogger<IdentityService>logger,UserManager<AppUser> userManager)
    : IIdentityService
{
    public async Task<Result<AppUserDto>> AuthenticateAsync(string email, string password, CancellationToken ct)
    {
        var user =await userManager.FindByEmailAsync(email);
        if(user is null)
        {
            logger.LogError("No user found for email = {email}", email);
            return ApplicationErrors.UserNotFound(email);
        }
        bool correctPass = await userManager.CheckPasswordAsync(user, password);
        if (!correctPass)
        {
            logger.LogError("Incorrect user name or password");
            return ApplicationErrors.InCorrectUserNameOrPassword;
        }
        var roles = await userManager.GetRolesAsync(user);
        var claims = await userManager.GetClaimsAsync(user);
        return new AppUserDto(user.Id,user.FirstName+' '+user.LastName,user.Email,user.PhoneNumber,
            roles,claims
            );
    }

    public Task<Result<bool>> AuthorizeAsync(string userId, string policyName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<AppUserDto>> GetUserByIdAsync(string userId, CancellationToken ct)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            logger.LogError("No user found for email = {userId}", userId);
            return ApplicationErrors.UserNotFound(userId);
        }
        return new AppUserDto(user.Id, user.FirstName + ' ' + user.LastName, user.Email, user.PhoneNumber,
            await userManager.GetRolesAsync(user),
            await userManager.GetClaimsAsync(user));
    }

    public async Task<Result<string>> GetUserNameAsync(string userId, CancellationToken ct)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            logger.LogError("No user found for email = {userId}", userId);
            return ApplicationErrors.UserNotFound(userId);
        }
       return user.FirstName + " " + user.LastName;
    }

    public async Task<Result<bool>> IsInRoleAsync(string userId, string roleName, CancellationToken ct)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            logger.LogError("No user found for email = {userId}", userId);
            return ApplicationErrors.UserNotFound(userId);
        }
      return await userManager.IsInRoleAsync(user,roleName);
    }

    public Task<Result<Success>> SignUpAsync(AppUserDto user, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
