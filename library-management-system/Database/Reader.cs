namespace library_management_system.Database;

public class Reader : User
{
    public List<double> Fines { get; set; } = new();
}