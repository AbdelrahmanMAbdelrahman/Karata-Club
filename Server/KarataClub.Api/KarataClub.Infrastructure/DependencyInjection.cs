

namespace KarataClub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddSqlServer( config).
            AddDepedencyInject();
        return services;
    }
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfigurationManager config)
    {
        string connectionString = config.GetConnectionString("ConnectionString")??"";
        ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }

    public static IServiceCollection AddDepedencyInject(this IServiceCollection servicies)
    {
        servicies.AddScoped<IAppDbContext, AppDbContext>();
        servicies.AddSingleton<IMediator,Mediator>();
        return servicies;

    }
    
}
