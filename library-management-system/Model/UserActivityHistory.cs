using System.ComponentModel.DataAnnotations;

namespace library_management_system.Model;

public class UserActivityHistory
{
    [Key] public int Id { get; init; }

    [Required]
    [StringLength(30)]
    public string? UserId { get; init; }

    [Required] public User? User { get; init; }

    [Required] 
    [StringLength(50)]
    public string? Activity { get; init; }

    [Required] public DateTime? ActivityTime { get; init; }
}