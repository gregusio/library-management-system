using BlazorBootstrap;

namespace library_management_system.Components.Layout;

public class NavigationMenu
{
    public static List<(string, string, IconName)> GetForReader()
    {
        return
        [
            ("books/all", "Books", IconName.Book),
            ("reserved-books", "Reserved", IconName.Bookmark),
            ("borrowed-books", "Borrowed", IconName.Book),
            ("activity-history", "History", IconName.Activity)
        ];
    }

    public static List<(string, string, IconName)> GetForLibrarian()
    {
        return
        [
            ("books/all", "Books", IconName.Book),
            ("readers", "Readers", IconName.People),
            ("borrow-book", "Borrow", IconName.Book),
            ("librarians", "Librarians", IconName.People)
        ];
    }
}