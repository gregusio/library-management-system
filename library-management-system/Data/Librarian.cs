namespace library_management_system.Data;

public class Librarian : User
{
    public double Salary { get; set; }

    public EPosition Position { get; set; }
}