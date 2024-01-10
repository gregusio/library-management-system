using System.ComponentModel.DataAnnotations;

namespace library_management_system.Database;

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
