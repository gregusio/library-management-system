using Microsoft.EntityFrameworkCore;

namespace library_management_system.Database;

public class Data : DbContext
{
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    
    public string DbPath { get; private set; }
    
    public Data()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BasicPersonInfo>()
            .HasIndex(t => t.Login)
            .IsUnique();

        modelBuilder.Entity<BasicPersonInfo>()
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
                    PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                    Salary = 1000,
                    Position = EPosition.Admin
                });
    }
}
