namespace library_management_system.Database;

public class Reader : User
{
    public List<BorrowedBook> BorrowedBooks { get; set; } = new();

    public List<ReservedBook> ReservedBooks { get; set; } = new();

    public List<double> Fines { get; set; } = new();
}