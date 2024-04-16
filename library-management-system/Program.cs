using library_management_system.Components;
using library_management_system.Components.Account;
using library_management_system.Data;
using library_management_system.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddTransient<DbApi>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<NavigationMenuService>();
builder.Services.AddTransient<AlertService>();
builder.Services.AddSingleton<NavigationMenuService>();
builder.Services.AddBlazorBootstrap();


builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

// var pass = builder.Configuration["password"]!;
//
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!.Replace("{password}", pass);
//
// builder.Services.AddDbContext<Data>(options =>
//     options.UseSqlServer(connectionString));

// var folder = Environment.SpecialFolder.LocalApplicationData;
// var path = Environment.GetFolderPath(folder);

var dbPath = "../library.db";

builder.Services.AddDbContext<DataDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));


builder.Services.AddScoped<DbInitializer>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbInitializer = services.GetRequiredService<DbInitializer>();
    dbInitializer.Initialize().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
