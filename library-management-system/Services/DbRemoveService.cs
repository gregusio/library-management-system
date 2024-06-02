using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbRemoveService(IDbContextFactory<DataDbContext> dbContextFactory)
{
    public async Task<EOperationResult> RemoveUser(User user)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            var trackedUser = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (trackedUser == null) return EOperationResult.DatabaseError;
            
            dbContext.Users.Remove(trackedUser);
            await dbContext.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> RemoveBook(Book book)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            
            var trackedBook = await dbContext.Books
                .FirstOrDefaultAsync(b => b.Id == book.Id);
            
            if (trackedBook == null) return EOperationResult.DatabaseError;
            
            dbContext.Books.Remove(trackedBook);
            await dbContext.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> ReturnBook(BorrowedBook borrowedBook)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var book = await dbContext.Books.FirstOrDefaultAsync(book => book.Id == borrowedBook.BookId);
            var bookInventory =
                await dbContext.BookInventories.FirstOrDefaultAsync(bookInventory =>
                    bookInventory.BookId == borrowedBook.BookId);

            if (book != null && bookInventory != null)
            {
                bookInventory.AvailableCopies += 1;
                bookInventory.BorrowedCopies -= 1;
            }
            
            var trackedBorrowedBook = await dbContext.BorrowedBooks
                .FirstOrDefaultAsync(b => b.Id == borrowedBook.Id);
            
            if (trackedBorrowedBook == null) return EOperationResult.DatabaseError;

            dbContext.BorrowedBooks.Remove(trackedBorrowedBook);

            await dbContext.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = borrowedBook.UserId,
                Activity = $"Returned book - title: {book?.Title}, author: {book?.Author}",
                ActivityTime = DateTime.Now
            });

            var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == borrowedBook.UserId);
            if (user == null) return EOperationResult.DatabaseError;
            user.BorrowedBooksCount -= 1;

            await dbContext.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> RemoveReservedBook(ReservedBook reservedBook)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var book = await dbContext.Books.FirstOrDefaultAsync(book => book.Id == reservedBook.BookId);
            var bookInventory =
                await dbContext.BookInventories.FirstOrDefaultAsync(bookInventory =>
                    bookInventory.BookId == reservedBook.BookId);

            if (book != null && bookInventory != null)
            {
                bookInventory.AvailableCopies += 1;
                bookInventory.ReservedCopies -= 1;
            }
            
            var trackedReservedBook = await dbContext.ReservedBooks
                .FirstOrDefaultAsync(b => b.Id == reservedBook.Id);
            
            if (trackedReservedBook == null) return EOperationResult.DatabaseError;

            dbContext.ReservedBooks.Remove(trackedReservedBook);

            await dbContext.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = reservedBook.UserId,
                Activity = $"Removed reservation - title: {book?.Title}, author: {book?.Author}",
                ActivityTime = DateTime.Now
            });

            var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == reservedBook.UserId);
            if (user == null) return EOperationResult.DatabaseError;
            user.ReservedBooksCount -= 1;

            await dbContext.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> RemoveFavoriteBook(User user, Book book)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var favoriteBook = await dbContext.FavoriteBooks.FirstOrDefaultAsync(favoriteBook =>
                favoriteBook.UserId == user.Id && favoriteBook.BookId == book.Id);
            if (favoriteBook == null) return EOperationResult.Success;

            dbContext.FavoriteBooks.Remove(favoriteBook);
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