using library_management_system.Data;
using library_management_system.Components.Layout;

namespace library_management_system.Services;

public class NavigationMenuService
{
    public INavigationMenu? CreateMenuForUser(User? user)
    {
        if (user == null)
            return new DefaultNavigationMenu();

        if(user.Role == "Librarian")
            return new LibrarianNavigationMenu();

        if(user.Role == "Reader")
            return new ReaderNavigationMenu();

        return null;
    }
}