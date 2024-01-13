using Microsoft.EntityFrameworkCore;

namespace library_management_system.Database;

public class Data(DbContextOptions<Data> options) : DbContext(options)
{
    public required DbSet<Reader> Readers { get; set; }
    public required DbSet<Book> Books { get; set; }
    public required DbSet<Librarian> Librarians { get; set; }

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