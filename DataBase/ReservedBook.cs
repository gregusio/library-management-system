using System.ComponentModel.DataAnnotations;

namespace DataBase;

public class ReservedBook
{
    [Key]
    public int Id { get; set; }
    
    public Reader Reader { get; set; }
    
    public BookInfo Book { get; set; }
}
