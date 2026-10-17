namespace KarataClub.Api.Services;

public class CurrentUser(IHttpContextAccessor accessor) : ICurrentUser
{
    public string Id {
        get => accessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    }
}
