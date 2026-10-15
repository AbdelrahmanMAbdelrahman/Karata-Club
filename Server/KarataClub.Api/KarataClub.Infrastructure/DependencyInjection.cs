using KarataClub.Infrastructure.Services;

namespace KarataClub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddSqlServer( config).
            AddDepedencyInject()
            .AddOptionsService()
            .AddCorsService()
            .AddJwtService(config)
            .AddAuthorization();
        return services;
    }
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration config)
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
        servicies.AddScoped<IAppDbContext>(provider=>provider.GetRequiredService<AppDbContext>());
        servicies.AddScoped<IIdentityService, IdentityService>();
        servicies.AddScoped<ITokenProvider, TokenProvider>();
        servicies.AddScoped<AppDbContextInitializer>();
        return servicies;

    }
    public static IServiceCollection AddCorsService(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("KarataClub", policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins(["http://localhost:4200"]);
            });
        });
        return services;
    }

    public static IServiceCollection AddOptionsService(this IServiceCollection services)
    {
        services.AddOptions<JwtOptions>()
            .BindConfiguration(nameof(JwtOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return services;
    }

    public static IServiceCollection AddJwtService(this IServiceCollection services,IConfiguration configuration)
    {
        JwtOptions? jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
        ArgumentNullException.ThrowIfNull(jwtOptions);
        //services.AddIdentityCore<AppUser>();
        services.AddIdentity<AppUser, Microsoft.AspNetCore.Identity.IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { 
            ValidateIssuer = true,
            ValidateAudience= true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime= true,
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            ValidIssuer=jwtOptions.Issuer,
            ValidAudience=jwtOptions.Audience,
            ClockSkew=TimeSpan.Zero,
            

            };
        });
       return services;
    }
    
}
