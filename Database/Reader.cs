namespace Database;

public class Reader : BasicPersonInfo
{
    public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
    
    public List<ReservedBook> ReservedBooks { get; set; } = new List<ReservedBook>();
    
    public List<double> Fines { get; set; } = new List<double>();
}
