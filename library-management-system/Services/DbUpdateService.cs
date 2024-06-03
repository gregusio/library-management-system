using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbUpdateService(DataDbContext db, IDbContextFactory<DataDbContext> dbContextFactory)
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
    
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            var trackedBorrowedBook = await dbContext.BorrowedBooks
                .Include(b => b.Book)
                .FirstOrDefaultAsync(b => b.Id == borrowedBook.Id);
            
            if (trackedBorrowedBook == null) return EOperationResult.DatabaseError;
            
            trackedBorrowedBook.RenewalCount++;
            trackedBorrowedBook.Deadline = trackedBorrowedBook.Deadline.AddDays(7);
    
            await dbContext.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = trackedBorrowedBook.UserId,
                Activity = "Postponed borrowing deadline for book " + trackedBorrowedBook.Book!.Title,
                ActivityTime = DateTime.Now
            });
    
            await dbContext.SaveChangesAsync();
    
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> UpdateBookInfo(Book book, BookInventory bookInventory)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            var trackedBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            
            if (trackedBook == null) return EOperationResult.DatabaseError;
            
            trackedBook.Title = book.Title;
            trackedBook.ISBN = book.ISBN;
            trackedBook.Author = book.Author;
            trackedBook.Publisher = book.Publisher;
            trackedBook.PublishDate = book.PublishDate;
            trackedBook.Description = book.Description;
            trackedBook.BookCover = book.BookCover;
            trackedBook.Category = book.Category;
            
            var trackedBookInventory = await dbContext.BookInventories.FirstOrDefaultAsync(b => b.BookId == book.Id);
            
            if (trackedBookInventory == null) return EOperationResult.DatabaseError;
            
            trackedBookInventory.AvailableCopies = bookInventory.AvailableCopies;
            
            await dbContext.SaveChangesAsync();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> UpdateUserInfo(User user)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            var trackedUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (trackedUser == null) return EOperationResult.DatabaseError;
            
            trackedUser.Name = user.Name;
            trackedUser.Surname = user.Surname;
            trackedUser.PhoneNumber = user.PhoneNumber;
            trackedUser.Address = user.Address;
            
            await dbContext.SaveChangesAsync();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<EOperationResult> UpdateUserAvatar(User user, Avatar avatar)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            var trackedUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (trackedUser == null) return EOperationResult.DatabaseError;
            
            trackedUser.Avatar = avatar;
            
            await dbContext.SaveChangesAsync();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }
}