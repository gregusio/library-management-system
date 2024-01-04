using library_managment_system.Components;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
//kolega mi napisal jakis przyklad
//Add to the database 
using var db = new Data();

var newReader = new Reader
{
    Name = "John",
    Surname = "Doe",
    Address = "123 Main St",
    TelephoneNr = "123-456-7890",
    EmailAddress = "john@example.com",
    Login = "johndoe",
    PasswordHash = "hashedpassword"
};
db.Readers.Add(newReader);
var newBookInfo = new BookInfo
{
    Title = "Sample Book",
    Author = "Sample Author",
    Publisher = "Sample Publisher",
    PublishDate = DateTime.Now, // Ustawienie daty na teraz
    Category = ECategory.Fantasy // Ustawienie odpowiedniej kategorii
};

var newBook = new Book
{
    info = newBookInfo,
    Available = 5, 
    NotAvailable = 0,
    Reserved = 0
};

db.Books.Add(newBook);
db.SaveChanges(); 

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Save in database 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
