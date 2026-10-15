using FluentValidation;
using KarataClub.Api.Infrastructure;
using System.Reflection;

namespace KarataClub.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddProblemDetails().AddControllers();
            services.AddExceptionHandler<GlobalExceptionHandler>()
               .AddEndpointsApiExplorer()
               .AddSwaggerGen(); ;
            return services;
        }
        
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
        {
           return builder.UseCors("KarataClub")
                .UseAuthentication()
                .UseAuthorization()
                .UseExceptionHandler();
        }
    }
}
