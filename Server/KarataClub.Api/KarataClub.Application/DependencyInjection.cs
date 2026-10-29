using FluentValidation;
using KarataClub.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KarataClub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection servicies)
    {
        servicies.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        servicies.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(CachingBehavior<,>));
        });
        return servicies;
    }
}
