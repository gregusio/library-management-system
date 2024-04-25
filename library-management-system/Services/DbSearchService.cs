using library_management_system.Model;

namespace library_management_system.Services;

public class DbSearchService(DataDbContext db)
{
    public List<User> GetAllReaders()
    {
        return db.Users.Where(user => user.Role == ERole.Reader).ToList();
    }

    public List<User> GetAllLibrarians()
    {
        return db.Users.Where(user => user.Role == ERole.Librarian).ToList();
    }

    public List<Book> GetAllBooks()
    {
        return db.Books.ToList();
    }

    public Book? GetBook(int id)
    {
        return db.Books.FirstOrDefault(book => book.Id == id);
    }

    public BookInventory? GetBookInventory(Book book)
    {
        try
        {
            return db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == book.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public List<BorrowedBook> GetBorrowedBooks(User reader)
    {
        return db.BorrowedBooks.Where(borrowedBook => borrowedBook.UserId == reader.Id).ToList();
    }

    public List<ReservedBook> GetReservedBooks(User reader)
    {
        return db.ReservedBooks.Where(reservedBook => reservedBook.UserId == reader.Id).ToList();
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return db.ReservedBooks.FirstOrDefault(reservedBook => reservedBook.UserId == reader.Id && reservedBook.BookId == book.Id);
    }
}