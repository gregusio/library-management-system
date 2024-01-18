using System.ComponentModel.DataAnnotations;

namespace library_management_system.Database;

public class Book
{
    [Key] public int BookId { get; set; } // Key 

    [StringLength(30)]
    public string? Title { get; set; }

    [StringLength(30)]
    public string? Author { get; set; }

    [StringLength(30)]
    public string? Publisher { get; set; }

    public DateTime PublishDate { get; set; }

    public ECategory Category { get; set; }

    public int Available { get; set; }

    public int NotAvailable { get; set; }

    public int Reserved { get; set; }
}