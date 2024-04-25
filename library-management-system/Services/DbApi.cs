using library_management_system.Model;

namespace library_management_system.Services;

public class DbApi(DataDbContext db)
{
    public List<User> GetAllReaders()
    {
        return new DbSearchService(db).GetAllReaders();
    }

    public List<User> GetAllLibrarians()
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

    public List<Book> GetAllBooks()
    {
        return new DbSearchService(db).GetAllBooks();
    }

    public List<BorrowedBook> GetBorrowedBooks(User reader)
    {
        return new DbSearchService(db).GetBorrowedBooks(reader);
    }

    public List<ReservedBook> GetReservedBooks(User reader)
    {
        return new DbSearchService(db).GetReservedBooks(reader);
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return new DbSearchService(db).GetReservedBook(reader, book);
    }

    public EOperationResult AddBook(Book book, int quantity)
    {
        return new DbInsertService(db).AddBook(book, quantity);
    }

    public EOperationResult AddBorrowedBook(User user, Book book)
    {
        return new DbInsertService(db).AddBorrowedBook(user, book);
    }
    
    public EOperationResult ChangeReservedToBorrowed(User user, ReservedBook reservedBook)
    {
        return new DbInsertService(db).ChangeReservedToBorrowed(user, reservedBook);
    }

    public EOperationResult AddReservedBook(User user, Book book)
    {
        return new DbInsertService(db).AddReservedBook(user, book);
    }

    public void RemoveUser(string id)
    {
        new DbRemoveService(db).RemoveUser(id);
    }

    public void RemoveBook(int id)
    {
        new DbRemoveService(db).RemoveBook(id);
    }

    public void RemoveBorrowedBook(BorrowedBook borrowedBook)
    {
        new DbRemoveService(db).RemoveBorrowedBook(borrowedBook);
    }

    public void RemoveReservedBook(ReservedBook reservedBook)
    {
        new DbRemoveService(db).RemoveReservedBook(reservedBook);
    }

    public void SaveChanges()
    {
        new DbUpdateService(db).SaveChanges();
    }

    public void PostponeBorrowedBook(BorrowedBook borrowedBook)
    {
        new DbUpdateService(db).PostponeBorrowedBook(borrowedBook);
    }
}