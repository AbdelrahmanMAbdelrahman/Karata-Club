


using KarataClub.Application.Features.People.Members.Dtos;

namespace KarataClub.Application.Common.Errors;

public static class ApplicationErrors
{
    public static Error InCorrectUserNameOrPassword=>Error.BadRequest("Identity.BadRequest","Incorrect username or passwrod");
    public static Error MemberAlreadyExist => Error.BadRequest("Identity.MemberAlreadyExist", "Member Already Exist");
    internal static Error InstructorAlreadyExist => Error.Conlict("InstructorErrors.InstructorAlreadyExist","Instructor already exist");

    public static  Error UserNotFound(string email) => Error.NotFound("AuthErrors.UserNotFound",$"No user found for email = {email}");

    public static Error MemberNotFound(Guid memberId) => Error.NotFound("MemberError.MemberNotFound", $"no member found for id = {memberId}");

    internal static Error InstructorNotFound(Guid instructorId)
    {
        throw new NotImplementedException();
    }
}
