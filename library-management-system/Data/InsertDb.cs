namespace library_management_system.Data;

public class InsertDb(DataDbContext db)
{
    public void AddReader(Reader reader)
    {
        
        try
        {
            db.Readers.Add(reader);
            db.SaveChanges();
        }
        catch (Exception e)
        {
            db.Readers.Remove(reader);
            throw;
        }
    }

    public void AddLibrarian(Librarian librarian)
    {
        try {
            db.Librarians.Add(librarian);
            db.SaveChanges();
        }
        catch (Exception e) {
            db.Librarians.Remove(librarian);
            throw;
        }
    }

    public void AddBook(Book book)
    {
        try {
            db.Books.Add(book);
            db.SaveChanges();
        } 
        catch (Exception e) {
            db.Books.Remove(book);
            throw;
        }
    }

    public void AddBorrowedBook(BorrowedBook borrowedBook)
    {
        var book = db.Books.FirstOrDefault(book => book.BookId == borrowedBook.BookId);
        if (book != null)
        {
            book.Available -= 1;
            book.NotAvailable += 1;
        }

        db.BorrowedBooks.Add(borrowedBook);
        db.SaveChanges();
    }

    public void AddReservedBook(ReservedBook reservedBook)
    {
        db.ReservedBooks.Add(reservedBook);
        db.SaveChanges();
    }
}