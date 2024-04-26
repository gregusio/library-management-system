using library_management_system.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace library_management_system.Services;

public class AuthService(UserManager<User> userManager)
{
    public async Task<User?> GetUser(AuthenticationStateProvider authenticationStateProvider)
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        if (!user.Identity!.IsAuthenticated) return null;

        return await userManager.GetUserAsync(user);
    }
}