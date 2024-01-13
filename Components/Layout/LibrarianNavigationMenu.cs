namespace library_management_system.Components.Layout;

public class LibrarianNavigationMenu : INavigationMenu
{
    public List<(string, string)> GetItems()
    {
        return
        [
            ("books", "Books"),
            ("readers", "Readers"),
            ("borrow-book", "Borrow book"),
            ("return-book", "Return book"),
            ("librarians", "Librarians"),
            ("logout", "Logout")
        ];
    }
}