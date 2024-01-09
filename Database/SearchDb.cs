namespace library_management_system.Database;

public class SearchDb
{
    private readonly Data _db = new Data();
    
    public Reader? GetReader(int id)
    {
        return _db.Readers.FirstOrDefault(reader => reader.Id == id);
    }
    
    public Reader? GetReader(string login)
    {
        return _db.Readers.FirstOrDefault(reader => reader.Login == login);
    }
    
    public Librarian? GetLibrarian(int id)
    {
        return _db.Librarians.FirstOrDefault(librarian => librarian.Id == id);
    }
    
    public Librarian? GetLibrarian(string login)
    {
        return _db.Librarians.FirstOrDefault(librarian => librarian.Login == login);
    }
    
    public List<Book> GetBooks(string title, string? author)
    {
        var books = _db.Books.Where(book => book.info.Title == title);
        if (author != null)
        {
            books = books.Where(book => book.info.Author == author);
        }
        return books.ToList();
    }
}