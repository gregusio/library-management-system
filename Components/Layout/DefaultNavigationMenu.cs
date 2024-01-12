namespace library_management_system.Components.Layout;

public class DefaultNavigationMenu : INavigationMenu
{
    public List<(string, string)> GetItems()
    {
        return
        [
            ("", "Login")
        ];
    }
}