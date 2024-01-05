namespace Database;

public class InsertDb
{
    private readonly Data _db = new Data();
    
    public void AddReader(Reader reader)
    {
        _db.Readers.Add(reader);
        _db.SaveChanges();
    }
    
    public void AddLibrarian(Librarian librarian)
    {
        _db.Librarians.Add(librarian);
        _db.SaveChanges();
    }
    
    public void AddBook(Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
    }
}