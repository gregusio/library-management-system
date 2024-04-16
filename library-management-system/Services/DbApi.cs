using library_management_system.Data;

namespace library_management_system.Services;

public class DbApi(DataDbContext db)
{
    public User? GetReader(int id)
    {
        return new SearchDb(db).GetReader(id);
    }

    public User? GetReader(string login)
    {
        return new SearchDb(db).GetReader(login);
    }

    public List<User> GetAllReaders()
    {
        return new SearchDb(db).GetAllReaders();
    }

    public User? GetLibrarian(int id)
    {
        return new SearchDb(db).GetLibrarian(id);
    }

    public User? GetLibrarian(string login)
    {
        return new SearchDb(db).GetLibrarian(login);
    }

    public List<User> GetAllLibrarians()
    {
        return new SearchDb(db).GetAllLibrarians();
    }

    public Book? GetBook(int id)
    {
        return new SearchDb(db).GetBook(id);
    }

    public List<Book> GetBooks(string title, string? author)
    {
        return new SearchDb(db).GetBooks(title, author);
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
    
    public bool LoginAlreadyUsed(string login)
    {
        return new SearchDb(db).LoginAlreadyUsed(login);
    }
    
    public bool PasswordAlreadyUsed(string password)
    {
        return new SearchDb(db).PasswordAlreadyUsed(password);
    }

    public void AddReader(User reader)
    {
        new InsertDb(db).AddReader(reader);
    }

    public void AddLibrarian(User librarian)
    {
        new InsertDb(db).AddLibrarian(librarian);
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

    public void RemoveReader(int id)
    {
        new RemoveDb(db).RemoveReader(id);
    }

    public void RemoveLibrarian(int id)
    {
        new RemoveDb(db).RemoveLibrarian(id);
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