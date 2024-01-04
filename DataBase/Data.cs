using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

public class Data : DbContext
{
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookInfo> BooksInfo { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<BasicPersonInfo> BasicPersonInfos { get; set; }
    public DbSet<BorrowedBook> BorrowedBooks { get; set; }
    public Data()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Tutaj ustawiasz dostawcę bazy danych, np. SQL Server
        optionsBuilder.UseSqlServer("connection_string_do_twojej_bazy_danych");
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

public class BookInfo : Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    
    public int BookId { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public ECategory Category;
    
}
public class Reader : BasicPersonInfo
{
    public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
    public List<BookInfo> ReservedBooks { get; set; } = new List<BookInfo>();
    public List<double> Fines { get; set; } = new List<double>();
}

public class BorrowedBook
{
    public int Id { get; set; }

    public int ReaderId { get; set; }
    public Reader Reader { get; set; }

    public BookInfo Book { get; set; }

    public DateTime Deadline { get; set; }
}
public class BasicPersonInfo
{
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
    public EPosition Position;

}

