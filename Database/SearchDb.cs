namespace library_management_system.Database;

public class SearchDb(Data db)
{
    public Reader? GetReader(int id)
    {
        return db.Readers.FirstOrDefault(reader => reader.Id == id);
    }

    public Reader? GetReader(string login)
    {
        return db.Readers.FirstOrDefault(reader => reader.Login == login);
    }

    public List<Reader> GetAllReaders()
    {
        return db.Readers.ToList();
    }

    public Librarian? GetLibrarian(int id)
    {
        return db.Librarians.FirstOrDefault(librarian => librarian.Id == id);
    }

    public Librarian? GetLibrarian(string login)
    {
        return db.Librarians.FirstOrDefault(librarian => librarian.Login == login);
    }

    public List<Librarian> GetAllLibrarians()
    {
        return db.Librarians.ToList();
    }

    public List<Book> GetBooks(string title, string? author)
    {
        var books = db.Books.Where(book => book.Title == title);
        if (author != null) books = books.Where(book => book.Author == author);
        return books.ToList();
    }

    public List<Book> GetAllBooks()
    {
        return db.Books.ToList();
    }
}