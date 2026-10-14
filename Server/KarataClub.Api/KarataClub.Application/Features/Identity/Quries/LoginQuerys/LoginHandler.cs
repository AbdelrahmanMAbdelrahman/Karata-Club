
namespace KarataClub.Application.Features.Identity.Quries.LoginQuerys
{
    public sealed class LoginHandler(
        ILogger<LoginHandler>logger,IIdentityService identity,ITokenProvider provider
        ) : IRequestHandler<LoginQuery, Result<TokenResponse>>
    {
        public async Task<Result<TokenResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
          Result<AppUserDto>user =await identity.AuthenticateAsync(request.Email,request.Password,cancellationToken);
            if (user is null)
            {
                logger.LogError("Incorrect userName or password");
                return ApplicationErrors.InCorrectUserNameOrPassword;
            }

           Result<TokenResponse>response=await provider.GenerateToken(user.Value,cancellationToken);
            if (response.IsFailure)
            {
                logger.LogError(string.Join(", ",response.Errors));
                return response.Errors;
            }
            return response.Value;
        }
    }
}
