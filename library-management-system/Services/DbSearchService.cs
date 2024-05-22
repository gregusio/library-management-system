using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbSearchService(DataDbContext db)
{
    public List<User>? GetAllReaders()
    {
        try
        {
            return db.Users
                .Include(user => user.Avatar)
                .Where(user => user.Role == ERole.Reader).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public List<User>? GetAllLibrarians()
    {
        try
        {
            return db.Users
                .Include(user => user.Avatar)
                .Where(user => user.Role == ERole.Librarian).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public List<Book>? GetAllBooks()
    {
        try
        {
            return db.Books
                .Include(b => b.BookCover)
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public Book? GetBook(int id)
    {
        try
        {
            return db.Books.FirstOrDefault(book => book.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public BookInventory? GetBookInventory(Book book)
    {
        try
        {
            return db.BookInventories
                .FirstOrDefault(bookInventory => bookInventory.BookId == book.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public List<BorrowedBook>? GetBorrowedBooks(User reader)
    {
        try
        {
            return db.BorrowedBooks
                .Include(b => b.Book)
                .Where(borrowedBook => borrowedBook.UserId == reader.Id)
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public List<ReservedBook>? GetReservedBooks(User reader)
    {
        try
        {
            return db.ReservedBooks
                .Include(b => b.Book)
                .Where(reservedBook => reservedBook.UserId == reader.Id)
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        try
        {
            return db.ReservedBooks
                .FirstOrDefault(reservedBook => reservedBook.UserId == reader.Id && reservedBook.BookId == book.Id);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public List<(string?, DateTime?)>? GetUserActivityHistory(User user)
    {
        try
        {
            return db.UserActivityHistories
                .Where(activity => activity.UserId == user.Id)
                .Select(activity => new { activity.Activity , activity.ActivityTime })
                .AsEnumerable()
                .Select(x => (x.Activity, x.ActivityTime))
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public List<Avatar>? GetAvatars()
    {
        try
        {
            return db.Avatars.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public List<Book>? GetFavoriteBooks(User user)
    {
        try
        {
            return db.FavoriteBooks
                .Include(favoriteBook => favoriteBook.Book)
                .Where(favoriteBook => favoriteBook.UserId == user.Id)
                .Select(favoriteBook => favoriteBook.Book)
                .ToList()!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public bool IsBookFavorite(User user, Book book)
    {
        try
        {
            return db.FavoriteBooks
                .Any(favoriteBook => favoriteBook.UserId == user.Id && favoriteBook.BookId == book.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}