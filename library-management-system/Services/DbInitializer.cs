using library_management_system.Data;
using Microsoft.AspNetCore.Identity;

public class DbInitializer
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task Initialize()
    {
        string adminEmail = "admin@example.com";
        string adminPassword = "Admin123#";

        if (await _roleManager.FindByNameAsync("admin") == null)
        {
            await _roleManager.CreateAsync(new IdentityRole("admin"));
        }

        if (await _userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new User {
                Name = "admin",
                Surname = "admin",
                Address = "admin",
                TelephoneNr = "admin",
                Role = "admin", 
                Email = adminEmail, 
                UserName = adminEmail 
            };

            IdentityResult result = await _userManager.CreateAsync(admin, adminPassword);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}