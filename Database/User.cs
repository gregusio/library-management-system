using System.ComponentModel.DataAnnotations;

namespace library_management_system.Database;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }
    
    public string Address { get; set; }
    
    public string TelephoneNr { get; set; }
    
    [EmailAddress]
    public string EmailAddress { get; set; }

    [Required]
    public string Login { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}
