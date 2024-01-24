using library_management_system.Components.Pages;
using library_management_system.Database;
using library_management_system.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace library_management_system.test;

public class LoginTest : TestContext
{
    [Fact]
    public void TestNoLoginNoPassword()
    {
        Services.AddTransient<DbApi>();
        Services.AddDbContext<Data>(
            options => options.UseSqlite($"Data Source=/home/gregusio/.local/share/library.db"));
        Services.AddSingleton<AuthService>();
        
        var cut = RenderComponent<Login>();
        cut.Find("button").Click();
        
        Assert.Equal("Invalid login or password", cut.Find("p").TextContent);
    }
    
    [Fact]
    public void TestLoginNoPassword()
    {
        Services.AddTransient<DbApi>();
        Services.AddDbContext<Data>(
            options => options.UseSqlite($"Data Source=/home/gregusio/.local/share/library.db"));
        Services.AddSingleton<AuthService>();
        
        var cut = RenderComponent<Login>();
        cut.Find("input").Change("admin");
        
        cut.Find("button").Click();
        
        Assert.Equal("Invalid login or password", cut.Find("p").TextContent);
    }
    
    [Fact]
    public void TestNoLoginPassword()
    {
        Services.AddTransient<DbApi>();
        Services.AddDbContext<Data>(
            options => options.UseSqlite($"Data Source=/home/gregusio/.local/share/library.db"));
        Services.AddSingleton<AuthService>();
        
        var cut = RenderComponent<Login>();
        cut
            .FindAll("input")
            .First(x => x.Id == "password")
            .Change("admin");
        
        cut.Find("button").Click();
        
        Assert.Equal("Invalid login or password", cut.Find("p").TextContent);
    }
    
    [Fact]
    public void TestLoginPassword()
    {
        Services.AddTransient<DbApi>();
        Services.AddDbContext<Data>(
            options => options.UseSqlite($"Data Source=/home/gregusio/.local/share/library.db"));
        Services.AddSingleton<AuthService>();
        
        var cut = RenderComponent<Login>();
        cut
            .FindAll("input")
            .First(x => x.Id == "username")
            .Change("admin");
        
        cut
            .FindAll("input")
            .First(x => x.Id == "password")
            .Change("admin");
        
        cut.Find("button").Click();
        
        AuthService auth = Services.GetService<AuthService>();
        Assert.True(auth.IsLoggedIn());
    }
}