
using KarataClub.Domain.Identity.Roles;

namespace KarataClub.Infrastructure.Data
{
    public  class AppDbContextInitializer(
        AppDbContext context,ILogger<AppDbContextInitializer>logger,
        UserManager<AppUser>userManager,RoleManager<IdentityRole>roleManager)
    {
       

        public  async Task SeedAsync()
        {
            if (await roleManager.Roles.AllAsync(r => r.Name != "Admin"))
               await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (await roleManager.Roles.AllAsync(r => r.Name != "Viewer"))
               await roleManager.CreateAsync(new IdentityRole("Viewer"));
            if (await roleManager.Roles.AllAsync(r => r.Name != "Reviewer"))
               await roleManager.CreateAsync(new IdentityRole("Reviewer"));
            if (await roleManager.Roles.AllAsync(r => r.Name != "Maker"))
               await roleManager.CreateAsync(new IdentityRole("Maker"));

           Result< AppUser> AdminResult = AppUser.Create("Abdelrahman","Hussien",
               "KarataAdmin@gmail.com","+201114308227", "KarataAdmin@gmail.com");
            if (AdminResult.IsFailure)
            {
                logger.LogError(string.Join(" - "), AdminResult.Errors);
                
            }
            AppUser Admin = AdminResult.Value;
            await userManager.CreateAsync(Admin,Admin.Email!.Substring(0,11)+"123$");
            await userManager.AddToRoleAsync(Admin,nameof(Role.Admin));
        }

        public  async Task InitialzeDbAsync()
        {
            if(await context.Database.EnsureCreatedAsync())
            {
                logger.LogError("Error Creating Database");
             
            }
        }
    }
}

public static class Initializer
{
    public static async Task InitializeAsync(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        AppDbContextInitializer initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
        await initializer.InitialzeDbAsync();
        await initializer.SeedAsync();
    }
}
