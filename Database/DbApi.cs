namespace library_management_system.Database;

public class DbApi
{
    public Reader? GetReader(int id)
    {
        return new SearchDb().GetReader(id);
    }
    
    public Reader? GetReader(string login)
    {
        return new SearchDb().GetReader(login);
    }
    
    public Librarian? GetLibrarian(int id)
    {
        return new SearchDb().GetLibrarian(id);
    }
    
    public Librarian? GetLibrarian(string login)
    {
        return new SearchDb().GetLibrarian(login);
    }
    
    public List<Book> GetBooks(string title, string? author)
    {
        return new SearchDb().GetBooks(title, author);
    }
    
    public void AddReader(Reader reader)
    {
        new InsertDb().AddReader(reader);
    }
    
    public void AddLibrarian(Librarian librarian)
    {
        new InsertDb().AddLibrarian(librarian);
    }
    
    public void AddBook(Book book)
    {
        new InsertDb().AddBook(book);
    }
    
    public void RemoveReader(int id)
    {
        new RemoveDb().RemoveReader(id);
    }
    
    public void RemoveLibrarian(int id)
    {
        new RemoveDb().RemoveLibrarian(id);
    }
    
    public void RemoveBook(int id)
    {
        new RemoveDb().RemoveBook(id);
    }
}