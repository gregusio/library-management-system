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
    
    public Task<bool> IsBookReserved(User user, Book book)
    {
        return db.ReservedBooks
            .AnyAsync(reservedBook => reservedBook.UserId == user.Id && reservedBook.BookId == book.Id);
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

    public async Task<double> GetBookAverageRating(Book book)
    {
        try
        {
            var reviews = await db.UsersBookRatings
                .Where(review => review.BookId == book.Id)
                .Select(review => review.Rating)
                .ToListAsync();

            return reviews.Count == 0 ? 0 : reviews.Average();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }
    
    public async Task<List<(string, int)>> GetBookAllRatings(Book book)
    {
        try
        {
            var list = await db.UsersBookRatings
                .Where(review => review.BookId == book.Id)
                .Select(review => new { review.User!.Name, review.Rating })
                .ToListAsync();
            
            return list.Select(y => (y.Name, y.Rating)).ToList()!;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<(string, int)>();
        }
    }
    
    public async Task<int> GetBookUserRating(User user, Book book)
    {
        try
        {
            var review = await db.UsersBookRatings
                .FirstOrDefaultAsync(review => review.UserId == user.Id && review.BookId == book.Id);

            return review?.Rating ?? 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }
}