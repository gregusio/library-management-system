using library_management_system.Database;

namespace library_management_system.Services;

public class DbApi
{
    private Data _db;

    public DbApi(Data db)
    {
        _db = db;
    }

    public Reader? GetReader(int id)
    {
        return new SearchDb(_db).GetReader(id);
    }

    public Reader? GetReader(string login)
    {
        return new SearchDb(_db).GetReader(login);
    }

    public List<Reader> GetAllReaders()
    {
        return new SearchDb(_db).GetAllReaders();
    }

    public Librarian? GetLibrarian(int id)
    {
        return new SearchDb(_db).GetLibrarian(id);
    }

    public Librarian? GetLibrarian(string login)
    {
        return new SearchDb(_db).GetLibrarian(login);
    }

    public List<Librarian> GetAllLibrarians()
    {
        return new SearchDb(_db).GetAllLibrarians();
    }

    public List<Book> GetBooks(string title, string? author)
    {
        return new SearchDb(_db).GetBooks(title, author);
    }

    public List<Book> GetAllBooks()
    {
        return new SearchDb(_db).GetAllBooks();
    }

    public void AddReader(Reader reader)
    {
        new InsertDb(_db).AddReader(reader);
    }

    public void AddLibrarian(Librarian librarian)
    {
        new InsertDb(_db).AddLibrarian(librarian);
    }

    public void AddBook(Book book)
    {
        new InsertDb(_db).AddBook(book);
    }

    public void RemoveReader(int id)
    {
        new RemoveDb(_db).RemoveReader(id);
    }

    public void RemoveLibrarian(int id)
    {
        new RemoveDb(_db).RemoveLibrarian(id);
    }

    public void RemoveBook(int id)
    {
        new RemoveDb(_db).RemoveBook(id);
    }

    public void SaveChanges()
    {
        new UpdateDb(_db).SaveChanges();
    }
}