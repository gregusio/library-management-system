namespace library_management_system.Data;

public class Reader : User
{
    public List<double> Fines { get; set; } = new();
}