using library_management_system.Model;

namespace library_management_system.Services;

public class DbRemoveService(DataDbContext db)
{
    public EOperationResult RemoveUser(string id)
    {
        try
        {
            var user = db.Users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult RemoveBook(int id)
    {
        try
        {
            var book = db.Books.FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult ReturnBook(BorrowedBook borrowedBook)
    {
        try
        {
            var book = db.Books.FirstOrDefault(book => book.Id == borrowedBook.BookId);
            var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == borrowedBook.BookId);
        
            if (book != null && bookInventory != null)
            {
                bookInventory.AvailableCopies += 1;
                bookInventory.BorrowedCopies -= 1;
            }

            db.BorrowedBooks.Remove(borrowedBook);
            
            db.UserActivityHistories.Add(new UserActivityHistory
            {
                UserId = borrowedBook.UserId,
                Activity = $"Returned book - title: {book?.Title}, author: {book?.Author}",
                ActivityTime = DateTime.Now
            });
            
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult RemoveReservedBook(ReservedBook reservedBook)
    {
        try
        {
            var book = db.Books.FirstOrDefault(book => book.Id == reservedBook.BookId);
            var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == reservedBook.BookId);
        
            if (book != null && bookInventory != null)
            {
                bookInventory.AvailableCopies += 1;
                bookInventory.ReservedCopies -= 1;
            }

            db.ReservedBooks.Remove(reservedBook);
            
            db.UserActivityHistories.Add(new UserActivityHistory
            {
                UserId = reservedBook.UserId,
                Activity = $"Removed reservation - title: {book?.Title}, author: {book?.Author}",
                ActivityTime = DateTime.Now
            });
            
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }
}