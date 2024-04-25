using library_management_system.Model;

namespace library_management_system.Services;

public class DbRemoveService(DataDbContext db)
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
        var book = db.Books.FirstOrDefault(book => book.Id == id);
        if (book != null)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }
    }

    public void RemoveBorrowedBook(BorrowedBook borrowedBook)
    {
        var book = db.Books.FirstOrDefault(book => book.Id == borrowedBook.BookId);
        var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == borrowedBook.BookId);
        
        if (book != null && bookInventory != null)
        {
            bookInventory.AvailableCopies += 1;
            bookInventory.BorrowedCopies -= 1;
        }

        db.BorrowedBooks.Remove(borrowedBook);
        db.SaveChanges();
    }

    public void RemoveReservedBook(ReservedBook reservedBook)
    {
        var book = db.Books.FirstOrDefault(book => book.Id == reservedBook.BookId);
        var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == reservedBook.BookId);
        
        if (book != null && bookInventory != null)
        {
            bookInventory.AvailableCopies += 1;
            bookInventory.ReservedCopies -= 1;
        }

        db.ReservedBooks.Remove(reservedBook);
        db.SaveChanges();
    }
}