using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace library_management_system.Model;

public class User : IdentityUser
{
    [Required] public int AvatarId { get; set; }

    [Required] public Avatar? Avatar { get; set; }

    [Required] [StringLength(100)] public string? Name { get; set; }

    [Required] [StringLength(100)] public string? Surname { get; set; }

    [StringLength(100)] public string? Address { get; set; }

    [StringLength(100)] public string? TelephoneNr { get; set; }

    [Required] [StringLength(30)] public ERole Role { get; init; }

    public int BorrowedBooksCount { get; set; }

    public int ReservedBooksCount { get; set; }
}