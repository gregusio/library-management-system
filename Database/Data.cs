using Microsoft.EntityFrameworkCore;

namespace library_management_system.Database;

public class Data : DbContext
{
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Librarian> Librarians { get; set; }

    public Data(DbContextOptions<Data> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(t => t.Login)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(t => t.PasswordHash)
            .IsUnique();

        modelBuilder.Entity<Librarian>()
            .HasData(
                new Librarian()
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Address = "Admin",
                    TelephoneNr = "Admin",
                    EmailAddress = "Admin",
                    Login = "admin",
                    PasswordHash =
                        "AQAAAAIAAYagAAAAECbeLHmwE9pGX99AVVY93sEwpWWdp3Z+nXXA9UC1XdMxerBrounmyXxu5EGvjtCA9w==",
                    Salary = 1000,
                    Position = EPosition.Admin
                });
    }
}