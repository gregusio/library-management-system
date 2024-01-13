namespace library_management_system.Database;

public class RemoveDb(Data db)
{
    public void RemoveReader(int id)
    {
        var reader = db.Readers.FirstOrDefault(reader => reader.Id == id);
        if (reader != null)
        {
            db.Readers.Remove(reader);
            db.SaveChanges();
        }
    }

    public void RemoveLibrarian(int id)
    {
        var librarian = db.Librarians.FirstOrDefault(librarian => librarian.Id == id);
        if (librarian != null)
        {
            db.Librarians.Remove(librarian);
            db.SaveChanges();
        }
    }

    public void RemoveBook(int id)
    {
        var book = db.Books.FirstOrDefault(book => book.BookId == id);
        if (book != null)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }
    }

    public void RemoveBorrowedBook(BorrowedBook borrowedBook)
    {
        db.BorrowedBooks.Remove(borrowedBook);
        db.SaveChanges();
    }

    public void RemoveReservedBook(ReservedBook reservedBook)
    {
        var book = db.Books.FirstOrDefault(book => book.BookId == reservedBook.BookId);
        if (book != null)
        {
            book.Available += 1;
            book.Reserved -= 1;
        }

        db.ReservedBooks.Remove(reservedBook);
        db.SaveChanges();
    }
}