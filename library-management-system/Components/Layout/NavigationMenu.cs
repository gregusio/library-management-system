using BlazorBootstrap;

namespace library_management_system.Components.Layout;

public class NavigationMenu
{
    public List<(string, string, IconName)> GetForReader()
    {
        return
        [
            ("books", "Books", IconName.Book),
            ("reserved-books", "Reserved Books", IconName.Bookmark),
            ("borrowed-books", "Borrowed Books", IconName.Book),
        ];
    }

    public List<(string, string, IconName)> GetForLibrarian()
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