namespace library_management_system.Data;

public class SearchDb(DataDbContext db)
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
        return db.Books.FirstOrDefault(book => book.BookId == id);
    }

    public List<BorrowedBook> GetBorrowedBooks(User reader)
    {
        return db.BorrowedBooks.Where(borrowedBook => borrowedBook.ReaderId == reader.Id).ToList();
    }

    public List<ReservedBook> GetReservedBooks(User reader)
    {
        return db.ReservedBooks.Where(reservedBook => reservedBook.ReaderId == reader.Id).ToList();
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return db.ReservedBooks.FirstOrDefault(reservedBook =>
            reservedBook.ReaderId == reader.Id && reservedBook.BookId == book.BookId);
    }
}