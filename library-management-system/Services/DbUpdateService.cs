using library_management_system.Model;

namespace library_management_system.Services;

public class DbUpdateService(DataDbContext db)
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