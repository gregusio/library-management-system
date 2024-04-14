using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace library_management_system.Data;

public class User : IdentityUser
{
    [Key] public int Id { get; set; }

    [Required, StringLength(30)] public string? Name { get; set; }

    [Required, StringLength(30)] public string? Surname { get; set; }

    [StringLength(30)]
    public string? Address { get; set; }

    [StringLength(30)]
    public string? TelephoneNr { get; set; }

    [EmailAddress, StringLength(30)] public string? EmailAddress { get; set; }

    [Required, StringLength(30)] public string? Login { get; set; }

    [Required, StringLength(30)] public string? Hash { get; set; }
    
    public User()
    {
    }

    public User(int id, string? name, string? surname, string? address, string? telephoneNr, string? emailAddress, string? login, string? hash)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Address = address;
        TelephoneNr = telephoneNr;
        EmailAddress = emailAddress;
        Login = login;
        Hash = hash;
    }
}