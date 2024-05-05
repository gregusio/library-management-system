using System.ComponentModel.DataAnnotations;

namespace library_management_system.Model;

public class Avatar
{
    [Key] public int Id { get; init; }
    
    [Required] public byte[]? Image { get; set; }
    
}