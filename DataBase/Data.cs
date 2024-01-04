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

    public Data()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        
    }
    
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

public class Librarian
{
    public double Salary { get; set; }
    
    
}
