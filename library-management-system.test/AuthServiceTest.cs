using library_management_system.Data;
using library_management_system.Services;

namespace library_management_system.test;

public class AuthServiceTest
{
    [Fact]
    public void TestIsLibrarian()
    {
        var authService = new AuthService();
        authService.User = new Librarian();
        Assert.True(authService.IsLibrarian());
    }
    
    [Fact]
    public void TestIsAdmin()
    {
        var authService = new AuthService();
        authService.User = new Librarian {Position = EPosition.Admin};
        Assert.True(authService.IsAdmin());
    }
    
    [Fact]
    public void TestIsReader()
    {
        var authService = new AuthService();
        authService.User = new Reader();
        Assert.True(authService.IsReader());
    }
    
    [Fact]
    public void TestIsLoggedIn()
    {
        var authService = new AuthService();
        authService.User = new Reader();
        Assert.True(authService.IsLoggedIn());
        
        authService.User = null;
        Assert.False(authService.IsLoggedIn());
        
        authService.User = new Librarian();
        Assert.True(authService.IsLoggedIn());
    }
}