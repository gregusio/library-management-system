using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_management_system.Model;

public class ReservedBook
{
    [Key] public int Id { get; init; }

    [ForeignKey("User")]
    [StringLength(450)]
    public string? UserId { get; init; }

    public User? User { get; init; }

    [ForeignKey("Book")] public int BookId { get; init; }

    public Book? Book { get; init; }
}