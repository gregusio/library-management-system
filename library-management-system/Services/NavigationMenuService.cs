using library_management_system.Data;
using library_management_system.Components.Layout;

namespace library_management_system.Services;

public class NavigationMenuService
{
    public INavigationMenu? CreateMenuForUser(User? user)
    {
        if(user == null)
            return null;

        if(user.Role == ERole.Librarian)
            return new LibrarianNavigationMenu();

        if(user.Role == ERole.Reader)
            return new ReaderNavigationMenu();

        return null;
    }
}