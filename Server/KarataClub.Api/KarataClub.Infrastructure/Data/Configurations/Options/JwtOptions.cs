namespace KarataClub.Infrastructure.Data.Configurations.Options;



public class JwtOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int Period { get; set; }
    public string Key { get; set; } = default!;
}
