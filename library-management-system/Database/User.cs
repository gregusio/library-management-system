using System.ComponentModel.DataAnnotations;

namespace library_management_system.Database;

public class User
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

    [Required, StringLength(30)] public string? PasswordHash { get; set; }
}