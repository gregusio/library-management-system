using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace library_management_system.Data;

public class User : IdentityUser
{
    [Required, StringLength(30)] public string? Name { get; set; }

    [Required, StringLength(30)] public string? Surname { get; set; }

    [StringLength(30)]
    public string? Address { get; set; }

    [StringLength(30)]
    public string? TelephoneNr { get; set; }

    [Required, StringLength(30)]
    public ERole Role { get; set; }

    public User()
    {
    }

    public User(string name, string surname, string address, string telephoneNr, ERole role)
    {
        Name = name;
        Surname = surname;
        Address = address;
        TelephoneNr = telephoneNr;
        Role = role;
    }
}