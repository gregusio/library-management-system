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

}