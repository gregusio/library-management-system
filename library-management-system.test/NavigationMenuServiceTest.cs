using library_management_system.Components.Layout;
using library_management_system.Database;
using library_management_system.Services;

namespace library_management_system.test;

public class NavigationMenuServiceTest
{
    [Fact]
    public void TestCreateMenuForReader()
    {
        var navigationMenuService = new NavigationMenuService();
        var user = new Reader();
        var menu = navigationMenuService.CreateMenuForUser(user);
        
        Assert.IsType<ReaderNavigationMenu>(menu);
    }
    
    [Fact]
    public void TestCreateMenuForLibrarian()
    {
        var navigationMenuService = new NavigationMenuService();
        var user = new Librarian();
        var menu = navigationMenuService.CreateMenuForUser(user);
        
        Assert.IsType<LibrarianNavigationMenu>(menu);
    }
    
    [Fact]
    public void TestCreateDefaultMenu()
    {
        var navigationMenuService = new NavigationMenuService();
        User? user = null;
        var menu = navigationMenuService.CreateMenuForUser(user);
        
        Assert.IsType<DefaultNavigationMenu>(menu);
    }
}