namespace library_management_system.Model;

public class RemoveDb(DataDbContext db)
{
    public void RemoveUser(string id)
    {
        var user = db.Users.FirstOrDefault(user => user.Id == id);
        if (user != null)
        {
            db.Users.Remove(user);
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