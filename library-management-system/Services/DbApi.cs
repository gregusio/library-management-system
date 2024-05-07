using library_management_system.Model;

namespace library_management_system.Services;

public class DbApi(DataDbContext db)
{
    public List<User>? GetAllReaders()
    {
        return new DbSearchService(db).GetAllReaders();
    }

    public List<User>? GetAllLibrarians()
    {
        return new DbSearchService(db).GetAllLibrarians();
    }

    public Book? GetBook(int id)
    {
        return new DbSearchService(db).GetBook(id);
    }
    
    public BookInventory? GetBookInventory(Book book)
    {
        return new DbSearchService(db).GetBookInventory(book);
    }

    public List<Book>? GetAllBooks()
    {
        return new DbSearchService(db).GetAllBooks();
    }

    public List<BorrowedBook>? GetBorrowedBooks(User reader)
    {
        return new DbSearchService(db).GetBorrowedBooks(reader);
    }

    public List<ReservedBook>? GetReservedBooks(User reader)
    {
        return new DbSearchService(db).GetReservedBooks(reader);
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return new DbSearchService(db).GetReservedBook(reader, book);
    }
    
    public List<(string?, DateTime?)>? GetUserActivityHistory(User user)
    {
        return new DbSearchService(db).GetUserActivityHistory(user);
    }
    
    public List<Avatar>? GetAvatars()
    {
        return new DbSearchService(db).GetAvatars();
    }

    public EOperationResult AddBook(Book book, int quantity, BookCover bookCover)
    {
        return new DbInsertService(db).AddBook(book, quantity, bookCover);
    }

    public EOperationResult BorrowBook(User user, Book book)
    {
        return new DbInsertService(db).BorrowBook(user, book);
    }
    
    public EOperationResult ChangeReservedToBorrowed(User user, ReservedBook reservedBook)
    {
        return new DbInsertService(db).ChangeReservedToBorrowed(user, reservedBook);
    }

    public EOperationResult ReserveBook(User user, Book book)
    {
        return new DbInsertService(db).ReserveBook(user, book);
    }

    public EOperationResult RemoveUser(string id)
    {
        return new DbRemoveService(db).RemoveUser(id);
    }

    public EOperationResult RemoveBook(int id)
    {
        return new DbRemoveService(db).RemoveBook(id);
    }

    public EOperationResult ReturnBook(BorrowedBook borrowedBook)
    {
        return new DbRemoveService(db).ReturnBook(borrowedBook);
    }

    public EOperationResult RemoveReservedBook(ReservedBook reservedBook)
    {
        return new DbRemoveService(db).RemoveReservedBook(reservedBook);
    }

    public EOperationResult SaveChanges()
    {
        return new DbUpdateService(db).SaveChanges();
    }

    public EOperationResult PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        return new DbUpdateService(db).PostponeBorrowedBook(borrowedBook);
    }
}