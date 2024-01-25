using Bunit.Extensions;
using library_management_system.Components.Pages;
using library_management_system.Database;
using library_management_system.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace library_management_system.test;

public class NoLoginTest : TestContext
{
    [Fact]
    public void NoLoginBooksSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        
        var cut = RenderComponent<Books>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }

    [Fact]
    public void NoLoginAccountSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        Services.AddTransient<AlertService>();
        
        var cut = RenderComponent<Account>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }
    
    [Fact]
    public void NoLoginLibrariansSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        Services.AddTransient<AlertService>();
        
        var cut = RenderComponent<Librarians>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }
    
    [Fact]
    public void NoLoginReadersSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        Services.AddTransient<AlertService>();
        
        var cut = RenderComponent<Readers>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }
    
    [Fact]
    public void NoLoginBorrowedBooksSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        Services.AddTransient<AlertService>();
        
        var cut = RenderComponent<BorrowedBooks>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }
    
    [Fact]
    public void NoLoginReservedBooksSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        Services.AddTransient<AlertService>();
        
        var cut = RenderComponent<ReservedBooks>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }

    [Fact]
    public void NoLoginReturnBookSite()
    {
        Services.AddTransient<DbApi>();
        var dbPath = "../../../../library.db";
        Services.AddDbContext<Data>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        Services.AddSingleton<AuthService>();
        Services.AddBlazorBootstrap();
        Services.AddTransient<AlertService>();
        
        var cut = RenderComponent<ReturnBook>();
        
        Assert.True(cut.Markup.IsNullOrEmpty() || cut.Find("h1").TextContent.Contains("User not logged in"));
    }
}