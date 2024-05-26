using System.ComponentModel.DataAnnotations;

namespace library_management_system.Model;

public class AddBookInputModel
{
    [Required]
    [Display(Name = "ISBN")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ISBN must be 13 characters")]
    public string ISBN { get; set; } = "";

    [Required] [Display(Name = "Title")] public string Title { get; set; } = "";

    [Required] [Display(Name = "Author")] public string Author { get; set; } = "";

    [Display(Name = "Publisher")] public string Publisher { get; set; } = "";

    [Display(Name = "Publish Date")] public DateTime PublishDate { get; set; } = DateTime.Now;

    [Display(Name = "Category")] public ECategory Category { get; set; } = ECategory.Fantasy;

    [Display(Name = "Amount")]
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int Amount { get; set; }

    [Required]
    [Display(Name = "Image")]
    public byte[] Image { get; set; } = File.ReadAllBytes("Images/BookCovers/default-cover.jpg");
}