namespace library_management_system.Database;

public class Reader : User
{
    public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
    
    public List<ReservedBook> ReservedBooks { get; set; } = new List<ReservedBook>();
    
    public List<double> Fines { get; set; } = new List<double>();
}
