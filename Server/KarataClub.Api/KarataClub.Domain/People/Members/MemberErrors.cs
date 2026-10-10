
namespace KarataClub.Domain.People.Members;

internal sealed class MemberErrors
{
    internal static Error InvalidEmergencyContactInfo => Error.Validation("MemberErrors.InvalidEmergencyContactInfo", "Invalid Invalid Emergency Contact Info");
    internal static Error InvalidPersonId=>Error.Validation("MemberErrors.InvalidPersonId", "Invalid Invalid Person Id");
    internal static Error InvalidLastBeltRankId=>Error.Validation("MemberErrors.InvalidLastBeltRankid", "Invalid Invalid Last Belt Rank Id");
}
