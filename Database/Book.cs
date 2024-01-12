using System.ComponentModel.DataAnnotations;

namespace library_management_system.Database;

public class Book
{
    [Key] public int BookId { get; set; } // Key 

    public string Title { get; set; }

    public string Author { get; set; }

    public string Publisher { get; set; }

    public DateTime PublishDate { get; set; }

    public ECategory Category { get; set; }

    public int Available { get; set; }

    public int NotAvailable { get; set; }

    public int Reserved { get; set; }
}