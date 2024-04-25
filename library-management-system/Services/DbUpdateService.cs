using library_management_system.Model;

namespace library_management_system.Services;

public class DbUpdateService(DataDbContext db)
{
    public EOperationResult SaveChanges()
    {
        try
        {
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        try
        {
            borrowedBook.Deadline = borrowedBook.Deadline.AddDays(7);
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }
}