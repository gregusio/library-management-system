using BlazorBootstrap;

namespace library_management_system.Components.Layout;

public class ReaderNavigationMenu : INavigationMenu
{
    public List<(string, string, IconName)> GetItems()
    {
        return
        [
            ("books", "Books", IconName.Book),
            ("reserved-books", "Reserved Books", IconName.Bookmark),
            ("borrowed-books", "Borrowed Books", IconName.Book),
        ];
    }
}