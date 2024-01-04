using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
}

public class Book
{
    [Key]
    public int BookId { get; set; } // Key 

    public BookInfo info { get; set; }
    
    public int Available { get; set; }
    
    public int NotAvailable { get; set; }
    
    public int Reserved { get; set; }
}

public class BookInfo
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public string Publisher { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public ECategory Category { get; set; }
}
public class Reader : BasicPersonInfo
{
    public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
    
    public List<ReservedBook> ReservedBooks { get; set; } = new List<ReservedBook>();
    
    public List<double> Fines { get; set; } = new List<double>();
}

public class BorrowedBook
{
    [Key]
    public int Id { get; set; }
    
    public Reader Reader { get; set; }
    
    public BookInfo Book { get; set; }
    
    public DateTime Deadline { get; set; }
}

public class ReservedBook
{
    [Key]
    public int Id { get; set; }
    
    public Reader Reader { get; set; }
    
    public BookInfo Book { get; set; }
}

public class BasicPersonInfo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }
    
    public string Address { get; set; }
    
    public string TelephoneNr { get; set; }
    
    [EmailAddress]
    public string EmailAddress { get; set; }

    [Required]
    public string Login { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}

public class Librarian : BasicPersonInfo
{
    public double Salary { get; set; }
    
    public EPosition Position { get; set; }
}
