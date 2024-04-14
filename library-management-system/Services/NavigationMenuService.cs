using library_management_system.Data;
using library_management_system.Components.Layout;

namespace library_management_system.Services;

public class NavigationMenuService
{
    public INavigationMenu? CreateMenuForUser(User? user)
    {
        if (user is Librarian)
            return new LibrarianNavigationMenu();
        if (user is Reader)
            return new ReaderNavigationMenu();
        return new DefaultNavigationMenu();
    }
}