


using KarataClub.Application.Features.People.Members.Dtos;

namespace KarataClub.Application.Common.Errors;

public static class ApplicationErrors
{
    public static Error InCorrectUserNameOrPassword;
    public static Error MemberAlreadyExist;

    public static  Error UserNotFound(string email) => Error.NotFound("AuthErrors.UserNotFound",$"No user found for email = {email}");

    public static Error MemberNotFound(Guid memberId) => Error.NotFound("MemberError.MemberNotFound", $"no member found for id = {memberId}");
   
}
