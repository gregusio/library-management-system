using library_management_system.Components.Layout;
using library_management_system.Database;
using library_management_system.Services;

namespace library_management_system.test;

public class NavigationMenuServiceTest
{
    [Fact]
    public void TestCreateMenuForUser()
    {
        var navigationMenuService = new NavigationMenuService();
        var user = new User();
        user = new Librarian();
        var menu = navigationMenuService.CreateMenuForUser(user);
        Assert.IsType<LibrarianNavigationMenu>(menu);
        
        user = new Reader();
        menu = navigationMenuService.CreateMenuForUser(user);
        Assert.IsType<ReaderNavigationMenu>(menu);
        
        user = null;
        menu = navigationMenuService.CreateMenuForUser(user);
        Assert.IsType<DefaultNavigationMenu>(menu);
    }
}