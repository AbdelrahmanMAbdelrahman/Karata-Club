namespace KarataClub.Application.Features.Identity.Quries.LoginQuerys;

public sealed record LoginQuery(string Email,string Password):IRequest<Result<TokenResponse>>;

