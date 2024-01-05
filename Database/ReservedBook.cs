using System.ComponentModel.DataAnnotations;

namespace library_management_system.Database;

public class ReservedBook
{
    [Key]
    public int Id { get; set; }
    
    public Reader Reader { get; set; }
    
    public BookInfo Book { get; set; }
}
