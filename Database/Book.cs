using System.ComponentModel.DataAnnotations;

namespace Database;

public class Book
{
    [Key]
    public int BookId { get; set; } // Key 

    public BookInfo info { get; set; }
    
    public int Available { get; set; }
    
    public int NotAvailable { get; set; }
    
    public int Reserved { get; set; }
}
