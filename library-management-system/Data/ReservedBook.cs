using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_management_system.Data;

public class ReservedBook
{
    [Key] public int Id { get; set; }

    [ForeignKey("User")] public string? ReaderId { get; set; }

    [ForeignKey("Book")] public int BookId { get; set; }
}