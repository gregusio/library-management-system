using library_management_system.Model;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Services;

public class DbInsertService(IDbContextFactory<DataDbContext> dbContextFactory, DbRemoveService removeService)
{
    private async Task<(EOperationResult, ReservedBook?)> IsBookReserved(User user, Book book)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var reservedBook = await dbContext.ReservedBooks.FirstOrDefaultAsync(reservedBook =>
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
            
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            await dbContext.BookCovers.AddAsync(bookCover);
            
            var book = new Book
            {
                Title = input.Title,
                Author = input.Author,
                BookCover = bookCover,
                Category = input.Category,
                ISBN = input.ISBN,
                PublishDate = input.PublishDate,
                Publisher = input.Publisher,
                Description = input.Description
            };
            
            await dbContext.Books.AddAsync(book);
            
            var bookInventory = new BookInventory
            {
                Book = book,
                AvailableCopies = input.Amount,
                BorrowedCopies = 0,
                ReservedCopies = 0
            };
            
            await dbContext.BookInventories.AddAsync(bookInventory);
            
            await dbContext.SaveChangesAsync();
            
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
            
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var bookInventory =
                await dbContext.BookInventories.FirstOrDefaultAsync(bookInventory => bookInventory.BookId == book.Id);

            if (bookInventory == null) return EOperationResult.UnexpectedError;

            if (bookInventory.AvailableCopies == 0) return EOperationResult.NoAvailableCopies;

            var borrowedBook = new BorrowedBook
            {
                UserId = user.Id,
                BookId = book.Id,
                Deadline = deadline,
                RenewalCount = 0
            };

            await dbContext.BorrowedBooks.AddAsync(borrowedBook);

            bookInventory.AvailableCopies--;
            bookInventory.BorrowedCopies++;
            user.BorrowedBooksCount++;

            await dbContext.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = user.Id,
                Activity = $"Borrowed a book - title: {book.Title}, author: {book.Author}",
                ActivityTime = DateTime.Now
            });

            await dbContext.SaveChangesAsync();

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
            var (bookStatus, _) = await IsBookReserved(user, book);
            if (bookStatus == EOperationResult.BookReserved) return EOperationResult.BookReserved;
            
            if (user.ReservedBooksCount >= 5) return EOperationResult.ReservedBookLimitExceeded;

            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var bookInventory =
                await dbContext.BookInventories.FirstOrDefaultAsync(bookInventory => bookInventory.BookId == book.Id);
            if (bookInventory == null) return EOperationResult.UnexpectedError;

            if (bookInventory.AvailableCopies == 0) return EOperationResult.NoAvailableCopies;

            var reservedBook = new ReservedBook
            {
                UserId = user.Id,
                BookId = book.Id
            };

            await dbContext.ReservedBooks.AddAsync(reservedBook);

            bookInventory.AvailableCopies--;
            bookInventory.ReservedCopies++;
            user.ReservedBooksCount++;

            await dbContext.UserActivityHistories.AddAsync(new UserActivityHistory
            {
                UserId = user.Id,
                Activity = $"Reserved a book - title: {book.Title}, author: {book.Author}",
                ActivityTime = DateTime.Now
            });

            await dbContext.SaveChangesAsync();

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
                BookId = book.Id
            };

            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            await dbContext.FavoriteBooks.AddAsync(favoriteBook);

            await dbContext.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }

    public async Task<EOperationResult> AddBookRating(User user, Book book, int rating)
    {
        try
        {
            await using var dbContext = await dbContextFactory.CreateDbContextAsync();
            if(await dbContext.UsersBookRatings.AnyAsync(review => review.UserId == user.Id && review.BookId == book.Id))
                dbContext.UsersBookRatings.RemoveRange(dbContext.UsersBookRatings.Where(review => review.UserId == user.Id && review.BookId == book.Id));
            
            var review = new UsersBookRating
            {
                UserId = user.Id,
                BookId = book.Id,
                Rating = rating
            };

            await dbContext.UsersBookRatings.AddAsync(review);

            await dbContext.SaveChangesAsync();

            return EOperationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return EOperationResult.DatabaseError;
        }
    }
}