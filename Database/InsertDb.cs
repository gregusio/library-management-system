namespace library_management_system.Database;

public class InsertDb(Data db)
{
    public void AddReader(Reader reader)
    {
        db.Readers.Add(reader);
        db.SaveChanges();
    }

    public void AddLibrarian(Librarian librarian)
    {
        db.Librarians.Add(librarian);
        db.SaveChanges();
    }

    public void AddBook(Book book)
    {
        db.Books.Add(book);
        db.SaveChanges();
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