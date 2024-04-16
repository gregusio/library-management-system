using BlazorBootstrap;

namespace library_management_system.Components.Layout;

public class LibrarianNavigationMenu : INavigationMenu
{
    public List<(string, string, IconName)> GetItems()
    {
        return
        [
            ("books", "Books", IconName.Book),
            ("readers", "Readers", IconName.People),
            ("borrow-book", "Borrow book", IconName.Book),
            ("return-book", "Return book", IconName.Book),
            ("librarians", "Librarians", IconName.People),
        ];
    }
}