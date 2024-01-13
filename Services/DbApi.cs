using library_management_system.Database;

namespace library_management_system.Services;

public class DbApi(Data db)
{
    public Reader? GetReader(int id)
    {
        return new SearchDb(db).GetReader(id);
    }

    public Reader? GetReader(string login)
    {
        return new SearchDb(db).GetReader(login);
    }

    public List<Reader> GetAllReaders()
    {
        return new SearchDb(db).GetAllReaders();
    }

    public Librarian? GetLibrarian(int id)
    {
        return new SearchDb(db).GetLibrarian(id);
    }

    public Librarian? GetLibrarian(string login)
    {
        return new SearchDb(db).GetLibrarian(login);
    }

    public List<Librarian> GetAllLibrarians()
    {
        return new SearchDb(db).GetAllLibrarians();
    }

    public List<Book> GetBooks(string title, string? author)
    {
        return new SearchDb(db).GetBooks(title, author);
    }

    public List<Book> GetAllBooks()
    {
        return new SearchDb(db).GetAllBooks();
    }

    public List<Tuple<Book, DateTime>> GetBorrowedBooks(Reader reader)
    {
        return new SearchDb(db).GetBorrowedBooks(reader);
    }

    public List<Book> GetReservedBooks(Reader reader)
    {
        return new SearchDb(db).GetReservedBooks(reader);
    }

    public void AddReader(Reader reader)
    {
        new InsertDb(db).AddReader(reader);
    }

    public void AddLibrarian(Librarian librarian)
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

    public void SaveChanges()
    {
        new UpdateDb(db).SaveChanges();
    }
}