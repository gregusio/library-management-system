using library_management_system.Model;

namespace library_management_system.Services;

public class DbUpdateService(DataDbContext db)
{
    public async Task<EOperationResult> SaveChanges()
    {
        try
        {
            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        try
        {
            if (borrowedBook.RenewalCount >= 2) return EOperationResult.RenewalLimitReached;

            borrowedBook.RenewalCount++;

            borrowedBook.Deadline = borrowedBook.Deadline.AddDays(7);

            await db.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = borrowedBook.UserId,
                User = borrowedBook.User,
                Activity = "Postponed borrowing deadline for book " + borrowedBook.Book!.Title,
                ActivityTime = DateTime.Now
            });

            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }
}