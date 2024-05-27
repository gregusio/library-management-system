using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbInsertService(DataDbContext db, DbRemoveService removeService)
{
    private async Task<(EOperationResult, ReservedBook?)> IsBookReserved(User user, Book book)
    {
        try
        {
            var reservedBook = await db.ReservedBooks.FirstOrDefaultAsync(reservedBook =>
                reservedBook.UserId == user.Id && reservedBook.BookId == book.Id);

            if (reservedBook == null) return (EOperationResult.BookNotReserved, null);

            return (EOperationResult.BookReserved, reservedBook);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (EOperationResult.DatabaseError, null);
        }
    }

    public async Task<EOperationResult> AddBook(AddBookInputModel input)
    {
        try
        {
            var bookCover = new BookCover
            {
                Image = input.Image
            };
            
            await db.BookCovers.AddAsync(bookCover);
            
            var book = new Book
            {
                Title = input.Title,
                Author = input.Author,
                BookCover = bookCover,
                Category = input.Category,
                ISBN = input.ISBN,
                PublishDate = input.PublishDate,
                Publisher = input.Publisher
            };
            
            await db.Books.AddAsync(book);
            
            var bookInventory = new BookInventory
            {
                Book = book,
                AvailableCopies = input.Amount,
                BorrowedCopies = 0,
                ReservedCopies = 0
            };
            
            await db.BookInventories.AddAsync(bookInventory);
            
            await db.SaveChangesAsync();
            
            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> BorrowBook(User user, Book book, DateTime deadline)
    {
        try
        {
            if (user.BorrowedBooksCount >= 5) return EOperationResult.BorrowedBookLimitExceeded;
            
            var (bookStatus, reservedBook) = await IsBookReserved(user, book);
            if (bookStatus == EOperationResult.BookReserved)
            {
                var result = await removeService.RemoveReservedBook(reservedBook!);
                if (result != EOperationResult.Success) return result;
            }
            
            var bookInventory =
                await db.BookInventories.FirstOrDefaultAsync(bookInventory => bookInventory.BookId == book.Id);

            if (bookInventory == null) return EOperationResult.UnexpectedError;

            if (bookInventory.AvailableCopies == 0) return EOperationResult.NoAvailableCopies;

            var borrowedBook = new BorrowedBook
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book,
                Deadline = deadline,
                RenewalCount = 0
            };

            await db.BorrowedBooks.AddAsync(borrowedBook);

            bookInventory.AvailableCopies--;
            bookInventory.BorrowedCopies++;
            user.BorrowedBooksCount++;

            await db.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = user.Id,
                User = user,
                Activity = $"Borrowed a book - title: {book.Title}, author: {book.Author}",
                ActivityTime = DateTime.Now
            });

            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> ReserveBook(User user, Book book)
    {
        try
        {
            if (user.ReservedBooksCount >= 5) return EOperationResult.ReservedBookLimitExceeded;

            var bookInventory =
                await db.BookInventories.FirstOrDefaultAsync(bookInventory => bookInventory.BookId == book.Id);
            if (bookInventory == null) return EOperationResult.UnexpectedError;

            if (bookInventory.AvailableCopies == 0) return EOperationResult.NoAvailableCopies;

            var reservedBook = new ReservedBook
            {
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book
            };

            await db.ReservedBooks.AddAsync(reservedBook);

            bookInventory.AvailableCopies--;
            bookInventory.ReservedCopies++;
            user.ReservedBooksCount++;

            await db.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = user.Id,
                User = user,
                Activity = $"Reserved a book - title: {book.Title}, author: {book.Author}",
                ActivityTime = DateTime.Now
            });

            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception)
        {
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> FavoriteBook(User user, Book book)
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

            await db.FavoriteBooks.AddAsync(favoriteBook);

            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }
}