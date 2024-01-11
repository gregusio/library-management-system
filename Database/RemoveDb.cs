namespace library_management_system.Database;

public class RemoveDb
{
    private readonly Data _db = Data.GetInstance();
    
    public void RemoveReader(int id)
    {
        var reader = _db.Readers.FirstOrDefault(reader => reader.Id == id);
        if (reader != null)
        {
            _db.Readers.Remove(reader);
            _db.SaveChanges();
        }
    }
    
    public void RemoveLibrarian(int id)
    {
        var librarian = _db.Librarians.FirstOrDefault(librarian => librarian.Id == id);
        if (librarian != null)
        {
            _db.Librarians.Remove(librarian);
            _db.SaveChanges();
        }
    }
    
    public void RemoveBook(int id)
    {
        var book = _db.Books.FirstOrDefault(book => book.BookId == id);
        if (book != null)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
        }
    }
}