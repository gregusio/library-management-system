namespace library_management_system.Database;

public class UpdateDb(Data db)
{
    public void SaveChanges()
    {
        db.SaveChanges();
    }

    public void PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        borrowedBook.Deadline = borrowedBook.Deadline.AddDays(7);
        db.SaveChanges();
    }
}