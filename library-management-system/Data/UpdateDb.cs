namespace library_management_system.Data;

public class UpdateDb(DataDbContext db)
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