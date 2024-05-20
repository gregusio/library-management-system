using library_management_system.Model;
using Microsoft.AspNetCore.Identity;

namespace library_management_system.Services;

public class DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
{
    public async Task Initialize()
    {
        var adminEmail = "admin@example.com";
        var adminPassword = "Admin123#";

        if (await roleManager.FindByNameAsync("admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
        }

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new User
            {
                AvatarId = 1,
                Avatar = null,
                Name = "admin",
                Surname = "admin",
                Address = "admin",
                TelephoneNr = "admin",
                Role = ERole.Admin,
                Email = adminEmail,
                UserName = adminEmail
            };

            var result = await userManager.CreateAsync(admin, adminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}