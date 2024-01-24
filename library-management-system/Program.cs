using library_management_system.Components;
using library_management_system.Database;
using library_management_system.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<DbApi>();

builder.Services.AddSingleton<AuthService>();

builder.Services.AddSingleton<NavigationMenuService>();

builder.Services.AddTransient<AlertService>();

builder.Services.AddBlazorBootstrap();

// var pass = builder.Configuration["password"]!;
//
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!.Replace("{password}", pass);
//
// builder.Services.AddDbContext<Data>(options =>
//     options.UseSqlServer(connectionString));

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = System.IO.Path.Join(path, "library.db");

builder.Services.AddDbContext<Data>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();