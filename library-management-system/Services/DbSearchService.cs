using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbSearchService(IDbContextFactory<DataDbContext> dbContextFactory)
{
    public async Task<List<User>?> GetAllReaders()
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Users
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Users
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Books
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.BookInventories
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.BorrowedBooks
                .Include(b => b.Book)
                .ThenInclude(b => b!.BookCover)
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.ReservedBooks
                .Include(b => b.Book)
                .ThenInclude(b => b!.BookCover)
                .Where(reservedBook => reservedBook.UserId == reader.Id)
                .ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public async Task<bool> IsBookReserved(User user, Book book)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        return await dbContext.ReservedBooks
            .AnyAsync(reservedBook => reservedBook.UserId == user.Id && reservedBook.BookId == book.Id);
    }

    public async Task<List<(string?, DateTime?)>?> GetUserActivityHistory(User user)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var activities = await dbContext.UserActivityHistories
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.Avatars.ToListAsync();
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return (await dbContext.FavoriteBooks
                .Include(favoriteBook => favoriteBook.Book)
                .ThenInclude(b => b!.BookCover)
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            return await dbContext.FavoriteBooks
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var reviews = await dbContext.UsersBookRatings
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var list = await dbContext.UsersBookRatings
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
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var review = await dbContext.UsersBookRatings
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