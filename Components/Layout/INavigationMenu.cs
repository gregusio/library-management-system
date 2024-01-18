using BlazorBootstrap;
using Microsoft.AspNetCore.Components.Routing;

namespace library_management_system.Components.Layout;

public interface INavigationMenu
{
    List<(string, string, IconName)> GetItems();
}