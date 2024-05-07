using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Model;

public class DataDbContext(DbContextOptions<DataDbContext> options) : IdentityDbContext<User>(options)
{

    public new required DbSet<User> Users { get; init; }
    public required DbSet<Book> Books { get; init; }
    public required DbSet<BookInventory> BookInventories { get; init; }
    public required DbSet<BorrowedBook> BorrowedBooks { get; init; }
    public required DbSet<ReservedBook> ReservedBooks { get; init; }
    public required DbSet<UserActivityHistory> UserActivityHistories { get; init; }
    
    public required DbSet<Avatar> Avatars { get; init; }
    
    public required DbSet<BookCover> BookCovers { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var folder = Path.Join("Images/Avatars");
        var files = Directory.GetFiles(folder);
        var id = 1;
        
        foreach (var file in files)
        {
            var image = File.ReadAllBytes(file);
            var avatar = new Avatar
            {
                Id = id++,
                Image = image
            };
            builder.Entity<Avatar>().HasData(avatar);
        }
        
        base.OnModelCreating(builder);
    }
}