using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Data;

public class DataDbContext(DbContextOptions<DataDbContext> options) : IdentityDbContext<User>(options)
{

    public new required DbSet<User> Users { get; set; }
    public required DbSet<Book> Books { get; set; }
    public required DbSet<BorrowedBook> BorrowedBooks { get; set; }
    public required DbSet<ReservedBook> ReservedBooks { get; set; }

}