using library_management_system.Model;

namespace library_management_system.Services;

public class DbApi(DbSearchService searchService, DbInsertService insertService, DbRemoveService removeService, DbUpdateService updateService)
{
    public Task<List<User>?> GetAllReaders()
    {
        return searchService.GetAllReaders();
    }

    public Task<List<User>?> GetAllLibrarians()
    {
        return searchService.GetAllLibrarians();
    }
    
    public Task<BookInventory?> GetBookInventory(Book book)
    {
        return searchService.GetBookInventory(book);
    }

    public Task<List<Book>?> GetAllBooks()
    {
        return searchService.GetAllBooks();
    }

    public Task<List<BorrowedBook>?> GetBorrowedBooks(User reader)
    {
        return searchService.GetBorrowedBooks(reader);
    }

    public Task<List<ReservedBook>?> GetReservedBooks(User reader)
    {
        return searchService.GetReservedBooks(reader);
    }

    public Task<ReservedBook?> GetReservedBook(User reader, Book book)
    {
        return searchService.GetReservedBook(reader, book);
    }
    
    public Task<List<(string?, DateTime?)>?> GetUserActivityHistory(User user)
    {
        return searchService.GetUserActivityHistory(user);
    }
    
    public Task<List<Avatar>?> GetAvatars()
    {
        return searchService.GetAvatars();
    }
    
    public Task<List<Book>?> GetFavoriteBooks(User user)
    {
        return searchService.GetFavoriteBooks(user);
    }

    public Task<bool> IsBookFavorite(User user, Book book)
    {
        return searchService.IsBookFavorite(user, book);
    }
    
    public Task<EOperationResult> AddBook(Book book, int quantity, BookCover bookCover)
    {
        return insertService.AddBook(book, quantity, bookCover);
    }

    public Task<EOperationResult> BorrowBook(User user, Book book, DateTime deadline)
    {
        return insertService.BorrowBook(user, book, deadline);
    }

    public Task<EOperationResult> ReserveBook(User user, Book book)
    {
        return insertService.ReserveBook(user, book);
    }
    
    public Task<EOperationResult> FavoriteBook(User user, Book book)
    {
        return insertService.FavoriteBook(user, book);
    }

    public Task<EOperationResult> RemoveUser(User user)
    {
        return removeService.RemoveUser(user);
    }

    public Task<EOperationResult> RemoveBook(Book book)
    {
        return removeService.RemoveBook(book);
    }

    public Task<EOperationResult> ReturnBook(BorrowedBook borrowedBook)
    {
        return removeService.ReturnBook(borrowedBook);
    }

    public Task<EOperationResult> RemoveReservedBook(ReservedBook reservedBook)
    {
        return removeService.RemoveReservedBook(reservedBook);
    }
    
    public Task<EOperationResult> RemoveFavoriteBook(User user, Book book)
    {
        return removeService.RemoveFavoriteBook(user, book);
    }

    public Task<EOperationResult> SaveChanges()
    {
        return updateService.SaveChanges();
    }

    public Task<EOperationResult> PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        return updateService.PostponeBorrowedBook(borrowedBook);
    }
}