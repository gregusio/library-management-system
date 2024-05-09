using library_management_system.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class AuthService(UserManager<User> userManager)
{
    public async Task<User?> GetUser(AuthenticationStateProvider authenticationStateProvider)
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var userClaim = authState.User;
        if (!userClaim.Identity!.IsAuthenticated) return null;
        
        var user = userManager.Users.Include(u => u.Avatar).FirstOrDefault(u => u.Email == userClaim.Identity.Name);
        return user;
    }
}