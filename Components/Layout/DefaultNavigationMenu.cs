using BlazorBootstrap;

namespace library_management_system.Components.Layout;

public class DefaultNavigationMenu : INavigationMenu
{
    public List<(string, string, IconName)> GetItems()
    {
        return
        [
            ("", "Login", IconName.PersonFill),
        ];
    }
}