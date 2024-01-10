namespace library_management_system.Components.Layout;

public class ReaderNavigationMenu : INavigationMenu
{
    public List<(string, string)> GetItems()
    {
        return
        [
            ("books", "Books"),
            ("reserved-books", "Reserved Books"),
            ("borrowed-books", "Borrowed Books"),
            ("logout", "Logout")
        ];
    }
}