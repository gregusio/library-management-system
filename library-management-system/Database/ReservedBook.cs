using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_management_system.Database;

public class ReservedBook
{
    [Key] public int Id { get; set; }

    [ForeignKey("Reader")] public int ReaderId { get; set; }

    [ForeignKey("Book")] public int BookId { get; set; }
}