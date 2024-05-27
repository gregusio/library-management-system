using library_management_system.Model;

namespace library_management_system.Services;

public class DbApi(DbSearchService searchService, DbInsertService insertService, DbRemoveService removeService, DbUpdateService updateService)
{
    public List<User>? GetAllReaders()
    {
        return searchService.GetAllReaders();
    }

    public List<User>? GetAllLibrarians()
    {
        return searchService.GetAllLibrarians();
    }
    
    public BookInventory? GetBookInventory(Book book)
    {
        return searchService.GetBookInventory(book);
    }

    public List<Book>? GetAllBooks()
    {
        return searchService.GetAllBooks();
    }

    public List<BorrowedBook>? GetBorrowedBooks(User reader)
    {
        return searchService.GetBorrowedBooks(reader);
    }

    public List<ReservedBook>? GetReservedBooks(User reader)
    {
        return searchService.GetReservedBooks(reader);
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return searchService.GetReservedBook(reader, book);
    }
    
    public List<(string?, DateTime?)>? GetUserActivityHistory(User user)
    {
        return searchService.GetUserActivityHistory(user);
    }
    
    public List<Avatar>? GetAvatars()
    {
        return searchService.GetAvatars();
    }
    
    public List<Book>? GetFavoriteBooks(User user)
    {
        return searchService.GetFavoriteBooks(user);
    }

    public bool IsBookFavorite(User user, Book book)
    {
        return searchService.IsBookFavorite(user, book);
    }
    
    public async Task<EOperationResult> AddBook(Book book, int quantity, BookCover bookCover)
    {
        return await insertService.AddBook(book, quantity, bookCover);
    }

    public async Task<EOperationResult> BorrowBook(User user, Book book)
    {
        return await insertService.BorrowBook(user, book);
    }
    
    public async Task<EOperationResult> ChangeReservedToBorrowed(User user, ReservedBook reservedBook)
    {
        return await insertService.ChangeReservedToBorrowed(user, reservedBook);
    }

    public async Task<EOperationResult> ReserveBook(User user, Book book)
    {
        return await insertService.ReserveBook(user, book);
    }
    
    public async Task<EOperationResult> FavoriteBook(User user, Book book)
    {
        return await insertService.FavoriteBook(user, book);
    }

    public EOperationResult RemoveUser(User user)
    {
        return removeService.RemoveUser(user);
    }

    public EOperationResult RemoveBook(Book book)
    {
        return removeService.RemoveBook(book);
    }

    public EOperationResult ReturnBook(BorrowedBook borrowedBook)
    {
        return removeService.ReturnBook(borrowedBook);
    }

    public EOperationResult RemoveReservedBook(ReservedBook reservedBook)
    {
        return removeService.RemoveReservedBook(reservedBook);
    }
    
    public EOperationResult RemoveFavoriteBook(User user, Book book)
    {
        return removeService.RemoveFavoriteBook(user, book);
    }

    public EOperationResult SaveChanges()
    {
        return updateService.SaveChanges();
    }

    public EOperationResult PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        return updateService.PostponeBorrowedBook(borrowedBook);
    }
}