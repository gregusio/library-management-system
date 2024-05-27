using System.ComponentModel.DataAnnotations;

namespace library_management_system.Model;

public class Book
{
    [Key] public int Id { get; init; }

    [Required] [StringLength(13)] public string? ISBN { get; set; }

    [StringLength(30)] public string? Title { get; set; }

    [StringLength(30)] public string? Author { get; set; }

    [StringLength(30)] public string? Publisher { get; set; }

    public DateTime PublishDate { get; set; }

    public ECategory Category { get; set; }

    [Required] public int BookCoverId { get; init; }

    [Required] public BookCover? BookCover { get; init; }
}