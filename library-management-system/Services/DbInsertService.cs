using library_management_system.Model;

namespace library_management_system.Services;

public class DbInsertService(DataDbContext db)
{
    public EOperationResult AddBook(Book book, int quantity)
    {
        try
        {
            db.Books.Add(book);
            
            db.BookInventories.Add(new BookInventory
            {
                BookId = book.Id,
                Book = book,
                AvailableCopies = quantity,
                BorrowedCopies = 0,
                ReservedCopies = 0
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

    public EOperationResult AddBorrowedBook(User user, Book book)
    {
        try
        {
            var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == book.Id);
        
            if(bookInventory == null)
            {
                return EOperationResult.UnexpectedError;
            }
            
            if(bookInventory.AvailableCopies == 0)
            {
                return EOperationResult.NoAvailableCopies;
            }
            
            var borrowedBook = new BorrowedBook
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book
            };

            db.BorrowedBooks.Add(borrowedBook);
            
            bookInventory.AvailableCopies--;
            bookInventory.BorrowedCopies++;
            
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult ChangeReservedToBorrowed(User user, ReservedBook reservedBook)
    {
        try
        {
            db.ReservedBooks.Remove(reservedBook);
            
            var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == reservedBook.BookId);
            
            if (bookInventory == null)
            {
                return EOperationResult.UnexpectedError;
            }
            
            bookInventory.ReservedCopies--;
            bookInventory.AvailableCopies++;

            return AddBorrowedBook(user, reservedBook.Book!);
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult AddReservedBook(User user, Book book)
    {
        try
        {
            var bookInventory = db.BookInventories.FirstOrDefault(bookInventory => bookInventory.BookId == book.Id);
            if (bookInventory == null)
            {
                return EOperationResult.UnexpectedError;
            }
        
            if (bookInventory.AvailableCopies == 0)
            {
                return EOperationResult.NoAvailableCopies;
            }
        
            var reservedBook = new ReservedBook
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book
            };
            
            db.ReservedBooks.Add(reservedBook);
            
            bookInventory.AvailableCopies--;
            bookInventory.ReservedCopies++;
            
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }
}