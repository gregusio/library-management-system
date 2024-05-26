using System.ComponentModel.DataAnnotations;

namespace library_management_system.Model;

public class AddUserInputModel
{
    [Required] [Display(Name = "Avatar")] public Avatar Avatar { get; set; } = new();

    [Required] [Display(Name = "Name")] public string Name { get; set; } = "";

    [Required] [Display(Name = "Surname")] public string Surname { get; set; } = "";

    [Display(Name = "Address")] public string Address { get; set; } = "";

    [Display(Name = "Phone number")] public string PhoneNumber { get; set; } = "";

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = "";

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = "";

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = "";
}