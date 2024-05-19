using library_management_system.Model;

namespace library_management_system.Services;

public class DbInsertService(DataDbContext db)
{
    public EOperationResult AddBook(Book book, int quantity, BookCover bookCover)
    {
        try
        {
            if (!AddBookCover(bookCover))
            {
                return EOperationResult.DatabaseError;
            }
            
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
    
    private bool AddBookCover(BookCover bookCover)
    {
        try
        {
            db.BookCovers.Add(bookCover);
            
            db.SaveChanges();
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public EOperationResult BorrowBook(User user, Book book)
    {
        try
        {
            if(user.BorrowedBooksCount >= 5)
            {
                return EOperationResult.BorrowedBookLimitExceeded;
            }
            
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
                Book = book,
                Deadline = DateTime.Now.AddDays(30),
                RenewalCount = 0
            };

            db.BorrowedBooks.Add(borrowedBook);
            
            bookInventory.AvailableCopies--;
            bookInventory.BorrowedCopies++;
            user.BorrowedBooksCount++;
            
            db.UserActivityHistories.Add(new UserActivityHistory
            {
                UserId = user.Id,
                User = user,
                Activity = $"Borrowed a book - title: {book.Title}, author: {book.Author}",
                ActivityTime = DateTime.Now
            });
            
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

            return BorrowBook(user, reservedBook.Book!);
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }

    public EOperationResult ReserveBook(User user, Book book)
    {
        try
        {
            if(user.ReservedBooksCount >= 5)
            {
                return EOperationResult.ReservedBookLimitExceeded;
            }
            
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
            user.ReservedBooksCount++;
            
            db.UserActivityHistories.Add(new UserActivityHistory
            {
                UserId = user.Id,
                User = user,
                Activity = $"Reserved a book - title: {book.Title}, author: {book.Author}",
                ActivityTime = DateTime.Now
            });
            
            db.SaveChanges();
            
            return EOperationResult.Success;
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }
    
    public EOperationResult FavoriteBook(User user, Book book)
    {
        try
        {
            var favoriteBook = new FavoriteBook
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book
            };
            
            db.FavoriteBooks.Add(favoriteBook);
            
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