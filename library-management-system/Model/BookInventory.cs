using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_management_system.Model;

public class BookInventory
{
    [Key] public int Id { get; init; }

    [Required] [ForeignKey("Book")] public int BookId { get; init; }

    public Book? Book { get; init; }

    public int AvailableCopies { get; set; }

    public int BorrowedCopies { get; set; }

    public int ReservedCopies { get; set; }
}