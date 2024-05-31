using System.ComponentModel.DataAnnotations;

namespace library_management_system.Model;

public class UsersBookRating
{
    [Key] public int Id { get; set; }
    
    [Required] 
    [StringLength(450)]
    public string? UserId { get; set; }
    
    [Required] public User? User { get; set; }
    
    [Required] public int BookId { get; set; }
    
    [Required] public int Rating { get; set; }
}