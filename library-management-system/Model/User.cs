using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace library_management_system.Model;

public class User : IdentityUser
{
    [Required, StringLength(30)] public string? Name { get; set; }

    [Required, StringLength(30)] public string? Surname { get; set; }

    [StringLength(30)]
    public string? Address { get; set; }

    [StringLength(30)]
    public string? TelephoneNr { get; set; }

    [Required, StringLength(30)]
    public ERole Role { get; init; }
}