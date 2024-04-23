using library_management_system.Model;

namespace library_management_system.Services;

public class DbApi(DataDbContext db)
{
    public List<User> GetAllReaders()
    {
        return new SearchDb(db).GetAllReaders();
    }

    public List<User> GetAllLibrarians()
    {
        return new SearchDb(db).GetAllLibrarians();
    }

    public Book? GetBook(int id)
    {
        return new SearchDb(db).GetBook(id);
    }

    public List<Book> GetAllBooks()
    {
        return new SearchDb(db).GetAllBooks();
    }

    public List<BorrowedBook> GetBorrowedBooks(User reader)
    {
        return new SearchDb(db).GetBorrowedBooks(reader);
    }

    public List<ReservedBook> GetReservedBooks(User reader)
    {
        return new SearchDb(db).GetReservedBooks(reader);
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return new SearchDb(db).GetReservedBook(reader, book);
    }

    public void AddBook(Book book)
    {
        new InsertDb(db).AddBook(book);
    }

    public void AddBorrowedBook(BorrowedBook borrowedBook)
    {
        new InsertDb(db).AddBorrowedBook(borrowedBook);
    }

    public void AddReservedBook(ReservedBook reservedBook)
    {
        new InsertDb(db).AddReservedBook(reservedBook);
    }

    public void RemoveUser(string id)
    {
        new RemoveDb(db).RemoveUser(id);
    }

    public void RemoveBook(int id)
    {
        new RemoveDb(db).RemoveBook(id);
    }

    public void RemoveBorrowedBook(BorrowedBook borrowedBook)
    {
        new RemoveDb(db).RemoveBorrowedBook(borrowedBook);
    }

    public void RemoveReservedBook(ReservedBook reservedBook)
    {
        new RemoveDb(db).RemoveReservedBook(reservedBook);
    }

    public void SaveChanges()
    {
        new UpdateDb(db).SaveChanges();
    }

    public void PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        new UpdateDb(db).PostponeBorrowedBook(borrowedBook);
    }
}