using KarataClub.Domain.Common.Results;
using KarataClub.Domain.Identity.AppUsers;

namespace KarataClub.Tests.Common.Identity;

public static class AppUserFactory
{
    public static Result<AppUser> Create (
        string? firstName=null,
        string? lastName=null,
        string? email=null,
        string? phone=null,
        string? userName=null)
    {
        return AppUser.Create(
            firstName??"ahmed",
            lastName??"hussien",
            email??"ahmed@gmail.com",
            phone??"01114308227",
            userName?? "ahmed@gmail.com"
            );
    }
}
