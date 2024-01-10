using Microsoft.AspNetCore.Components.Routing;

namespace library_management_system.Components.Layout;

public class LibrarianNavigationMenu : INavigationMenu
{
    public List<(string, string)> GetItems()
    {
        return
        [
            ("books", "Books"),
            ("readers", "Readers"),
            ("librarians", "Librarians"),
            ("logout", "Logout")
        ];
    }
}