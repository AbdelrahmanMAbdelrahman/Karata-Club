namespace KarataClub.Domain.People;

internal sealed class PersonErrors
{
    internal static Error InvalidName => Error.Validation("PersonErrors.InvalidName", "Provide A valid name");
    internal static Error InvalidAddress=>Error.Validation("PersonErrors.InvalidAddress", "Provide A valid address");
    internal static Error InvalidEmail=>Error.Validation("PersonErrors.InvalidEmail", "Provide A valid email");
    internal static Error InvalidPhone=>Error.Validation("PersonErrors.InvalidPhone", "Provide A valid phone");
}
