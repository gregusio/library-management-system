using Microsoft.EntityFrameworkCore;

namespace Database;

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
    }
}
