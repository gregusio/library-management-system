using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_management_system.Model;

public class ReservedBook
{
    [Key] public int Id { get; init; }

    [ForeignKey("User")] 
    [StringLength(30)]
    public string? ReaderId { get; init; }

    [ForeignKey("Book")] public int BookId { get; init; }
}