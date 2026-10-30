 namespace KarataClub.Domain.Identity.AppUsers;

public sealed class AppUser:IdentityUser
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;

    private AppUser()
    {
    }
    private AppUser(Guid id,string firstName,string lastName,string email,string phone,string userName)
    {
        Id = id.ToString();
     Email = email;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phone;
        UserName = userName;
    }

    public static Result<AppUser> Create(
        string firstName, string lastName, string email, string phone, string userName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) return AppUserErrors.InvalidFirstName;
        if (string.IsNullOrWhiteSpace(lastName)) return AppUserErrors.InvalidLastName;
        if (string.IsNullOrWhiteSpace(email)) return AppUserErrors.InvalidEmail;
        if (string.IsNullOrWhiteSpace(phone)) return AppUserErrors.InvalidPhone;
        if (string.IsNullOrWhiteSpace(userName)) return AppUserErrors.InvalidUserName;

        return new AppUser(Guid.NewGuid(),firstName,lastName,email,phone,userName);
    }
}
