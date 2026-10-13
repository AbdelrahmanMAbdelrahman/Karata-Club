namespace KarataClub.Api
{
    public static class DependencyInjection
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
        {
           return builder.UseCors("KarataClub")
                .UseAuthentication()
                .UseAuthorization();
        }
    }
}
