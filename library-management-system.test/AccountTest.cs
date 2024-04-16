using library_management_system.Components.Pages;
using library_management_system.Data;
using library_management_system.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace library_management_system.test;

public class AccountTest : TestContext
{
    // [Fact]
    // public void AccountTest1()
    // {
    //     Services.AddTransient<DbApi>();
    //     Services.AddDbContext<Data>(
    //         options => options.UseSqlite($"Data Source=/home/gregusio/.local/share/library.db"));
    //     Services.AddSingleton<AuthService>();
    //     Services.AddTransient<AlertService>();
    //     Services.AddBlazorBootstrap();
    //     
    //     var auth = Services.GetRequiredService<AuthService>();
    //     var db = Services.GetRequiredService<DbApi>();
    //     var user = db.GetLibrarian(1);
    //     auth.User = user;
    //     
    //     var cut = RenderComponent<Account>();
    //     cut.Find("button").Click();
    // }
}