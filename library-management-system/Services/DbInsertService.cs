using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbInsertService(DataDbContext db)
{
    private async Task<EOperationResult> AddBookCover(BookCover bookCover)
    {
        try
        {
            await db.BookCovers.AddAsync(bookCover);

            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> AddBook(Book book, int quantity, BookCover bookCover)
    {
        try
        {
            var result = await AddBookCover(bookCover);

            if (result == EOperationResult.DatabaseError) return EOperationResult.DatabaseError;

            await db.Books.AddAsync(book);

            await db.BookInventories.AddAsync(new BookInventory
            {
                BookId = book.Id,
                Book = book,
                AvailableCopies = quantity,
                BorrowedCopies = 0,
                ReservedCopies = 0
            });

            await db.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> BorrowBook(User user, Book book)
    {
        try
        {
            if (user.BorrowedBooksCount >= 5) return EOperationResult.BorrowedBookLimitExceeded;

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
                Deadline = DateTime.Now.AddDays(30),
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

    public async Task<EOperationResult> ChangeReservedToBorrowed(User user, ReservedBook reservedBook)
    {
        try
        {
            db.ReservedBooks.Remove(reservedBook);

            var bookInventory =
                await db.BookInventories.FirstOrDefaultAsync(bookInventory =>
                    bookInventory.BookId == reservedBook.BookId);

            if (bookInventory == null) return EOperationResult.UnexpectedError;

            bookInventory.ReservedCopies--;
            bookInventory.AvailableCopies++;

            return await BorrowBook(user, reservedBook.Book!);
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