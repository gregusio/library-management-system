using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbSearchService(DataDbContext db)
{
    public async Task<List<User>?> GetAllReaders()
    {
        try
        {
            return await db.Users
                .Include(user => user.Avatar)
                .Where(user => user.Role == ERole.Reader)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<User>?> GetAllLibrarians()
    {
        try
        {
            return await db.Users
                .Include(user => user.Avatar)
                .Where(user => user.Role == ERole.Librarian)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<Book>?> GetAllBooks()
    {
        try
        {
            return await db.Books
                .Include(b => b.BookCover)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<BookInventory?> GetBookInventory(Book book)
    {
        try
        {
            return await db.BookInventories
                .FirstOrDefaultAsync(bookInventory => bookInventory.BookId == book.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<BorrowedBook>?> GetBorrowedBooks(User reader)
    {
        try
        {
            return await db.BorrowedBooks
                .Include(b => b.Book)
                .Where(borrowedBook => borrowedBook.UserId == reader.Id)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<ReservedBook>?> GetReservedBooks(User reader)
    {
        try
        {
            return await db.ReservedBooks
                .Include(b => b.Book)
                .Where(reservedBook => reservedBook.UserId == reader.Id)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<ReservedBook?> GetReservedBook(User reader, Book book)
    {
        try
        {
            return await db.ReservedBooks
                .FirstOrDefaultAsync(reservedBook =>
                    reservedBook.UserId == reader.Id && reservedBook.BookId == book.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<(string?, DateTime?)>?> GetUserActivityHistory(User user)
    {
        try
        {
            var activities = await db.UserActivityHistories
                .Where(activity => activity.UserId == user.Id)
                .Select(activity => new { activity.Activity, activity.ActivityTime })
                .ToListAsync();

            return activities
                .Select(x => (x.Activity, x.ActivityTime))
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<Avatar>?> GetAvatars()
    {
        try
        {
            return await db.Avatars.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<List<Book>?> GetFavoriteBooks(User user)
    {
        try
        {
            return (await db.FavoriteBooks
                .Include(favoriteBook => favoriteBook.Book)
                .Where(favoriteBook => favoriteBook.UserId == user.Id)
                .Select(favoriteBook => favoriteBook.Book)
                .ToListAsync())!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<bool> IsBookFavorite(User user, Book book)
    {
        try
        {
            return await db.FavoriteBooks
                .AnyAsync(favoriteBook => favoriteBook.UserId == user.Id && favoriteBook.BookId == book.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}