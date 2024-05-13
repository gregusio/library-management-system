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
            if(borrowedBook.RenewalCount >= 2)
            {
                return EOperationResult.RenewalLimitReached;
            }
            
            borrowedBook.RenewalCount++;
            
            borrowedBook.Deadline = borrowedBook.Deadline.AddDays(7);
            
            db.UserActivityHistories.Add(new UserActivityHistory
            {
                UserId = borrowedBook.UserId,
                User = borrowedBook.User,
                Activity = "Postponed borrowing deadline for book " + borrowedBook.Book!.Title,
                ActivityTime = DateTime.Now
            });
            
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