
namespace KarataClub.Infrastructure.Services
{
    public sealed class TokenProvider(
        IAppDbContext context,
        IOptions<JwtOptions>options,
        ILogger<TokenProvider>logger
        ) : ITokenProvider
    {
        public async Task<Result<TokenResponse>> GenerateToken(AppUserDto user, CancellationToken ct)
        {
            Result<TokenResponse> tokenRes = await Create(user,ct);
            if (tokenRes.IsFailure)
            {
                logger.LogError(string.Join("-", tokenRes.Errors));
                return tokenRes.Errors;
            }
            return tokenRes.Value;
        }

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string Token)
        {
           TokenValidationParameters validationParameters = new TokenValidationParameters
           {
               ValidateAudience = true,
               ValidateIssuer = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer=options.Value.Issuer,
               ValidAudience=options.Value.Audience,
               IssuerSigningKey=
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token)),
               ClockSkew=TimeSpan.Zero
           };
            ClaimsPrincipal principal = new JwtSecurityTokenHandler()
                .ValidateToken(Token, validationParameters, out SecurityToken validatedToken);
            if(validatedToken is not JwtSecurityToken securityToken ||
                !securityToken.SignatureAlgorithm.Equals( SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException();
            }
            return principal;
        }

        public async Task<Result< TokenResponse>> Create(AppUserDto user,CancellationToken ct)
        {
            DateTime expireOn = DateTime.UtcNow.AddMinutes(options.Value.Period);
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Name,user.Name),
            };
            foreach(var role in user.Role)
            {
                claims.Add(new Claim( ClaimTypes.Role,role));
            }
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor() { 
                Subject=new ClaimsIdentity(claims),
            Issuer=options.Value.Issuer,
            Audience=options.Value.Audience,
            Expires=expireOn,
            SigningCredentials=new SigningCredentials(
              new SymmetricSecurityKey( Encoding.UTF8.GetBytes(options.Value.Key)),
              SecurityAlgorithms.HmacSha256
                ),
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(descriptor);
            await context.RefreshTokens
                .Where(rf=>rf.UserId==user.Id)
                .ExecuteDeleteAsync(ct);

            Result<RefreshToken> createRefreshTokenRes = RefreshToken.Create(user.Id,GenerateRefreshToken(),
                DateTime.UtcNow.AddDays(7));
            if (createRefreshTokenRes.IsFailure)
            {
                logger.LogError(string.Join("-", createRefreshTokenRes.Errors));
                return createRefreshTokenRes.Errors;
            }
            await context.RefreshTokens.AddAsync(createRefreshTokenRes.Value,ct);
            await context.SaveChangesAsync(ct);
            return new TokenResponse(handler.WriteToken(token),createRefreshTokenRes.Value.Token,expireOn);
        }
        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }
    }
}
