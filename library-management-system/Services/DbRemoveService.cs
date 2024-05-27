using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbRemoveService(DataDbContext db)
{
    public async Task<EOperationResult> RemoveUser(User user)
    {
        try
        {
            db.Users.Remove(user);
            await db.SaveChangesAsync();

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
            db.Books.Remove(book);
            await db.SaveChangesAsync();

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
            var book = await db.Books.FirstOrDefaultAsync(book => book.Id == borrowedBook.BookId);
            var bookInventory =
                await db.BookInventories.FirstOrDefaultAsync(bookInventory =>
                    bookInventory.BookId == borrowedBook.BookId);

            if (book != null && bookInventory != null)
            {
                bookInventory.AvailableCopies += 1;
                bookInventory.BorrowedCopies -= 1;
            }

            db.BorrowedBooks.Remove(borrowedBook);

            await db.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = borrowedBook.UserId,
                Activity = $"Returned book - title: {book?.Title}, author: {book?.Author}",
                ActivityTime = DateTime.Now
            });

            var user = await db.Users.FirstOrDefaultAsync(user => user.Id == borrowedBook.UserId);
            if (user == null) return EOperationResult.DatabaseError;
            user.BorrowedBooksCount -= 1;

            await db.SaveChangesAsync();

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
            var book = await db.Books.FirstOrDefaultAsync(book => book.Id == reservedBook.BookId);
            var bookInventory =
                await db.BookInventories.FirstOrDefaultAsync(bookInventory =>
                    bookInventory.BookId == reservedBook.BookId);

            if (book != null && bookInventory != null)
            {
                bookInventory.AvailableCopies += 1;
                bookInventory.ReservedCopies -= 1;
            }

            db.ReservedBooks.Remove(reservedBook);

            await db.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = reservedBook.UserId,
                Activity = $"Removed reservation - title: {book?.Title}, author: {book?.Author}",
                ActivityTime = DateTime.Now
            });

            var user = await db.Users.FirstOrDefaultAsync(user => user.Id == reservedBook.UserId);
            if (user == null) return EOperationResult.DatabaseError;
            user.ReservedBooksCount -= 1;

            await db.SaveChangesAsync();

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
            var favoriteBook = await db.FavoriteBooks.FirstOrDefaultAsync(favoriteBook =>
                favoriteBook.UserId == user.Id && favoriteBook.BookId == book.Id);
            if (favoriteBook == null) return EOperationResult.Success;

            db.FavoriteBooks.Remove(favoriteBook);
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