
namespace KarataClub.Domain.Identity.AppUsers;

internal class AppUserErrors
{
    internal static Error InvalidFirstName=Error.Validation("AppUserErrors.InvalidFirstName", "Invalid First Name");
    internal static Error InvalidLastName=Error.Validation("AppUserErrors.InvalidLastName", "Invalid Last Name");
    internal static Error InvalidEmail=Error.Validation("AppUserErrors.InvalidEmail", "Invalid Email");
    internal static Error InvalidPhone=Error.Validation("AppUserErrors.InvalidPhone", "Invalid Phone");
    internal static Error InvalidUserName=Error.Validation("AppUserErrors.InvalidUserName", "Invalid User Name");
}
