namespace library_management_system.Data;

public class RemoveDb(DataDbContext db)
{
    public void RemoveReader(int id)
    {
        // var reader = db.Users.FirstOrDefault(reader => reader.Id == id);
        // if (reader != null)
        // {
        //     db.Users.Remove(reader);
        //     db.SaveChanges();
        // }
    }

    public void RemoveLibrarian(int id)
    {
        // var librarian = db.Users.FirstOrDefault(librarian => librarian.Id == id);
        // if (librarian != null)
        // {
        //     db.Users.Remove(librarian);
        //     db.SaveChanges();
        // }
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
        var book = db.Books.FirstOrDefault(book => book.BookId == borrowedBook.BookId);
        if (book != null)
        {
            book.Available += 1;
            book.NotAvailable -= 1;
        }

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