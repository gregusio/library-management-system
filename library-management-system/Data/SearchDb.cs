using Microsoft.AspNetCore.Identity;

namespace library_management_system.Data;

public class SearchDb(DataDbContext db)
{
    public User? GetReader(int id)
    {
        // return db.Users.FirstOrDefault(reader => reader.Id == id);
        return null;
    }

    public User? GetReader(string login)
    {
        // return db.Users.FirstOrDefault(reader => reader.Login == login);
        return null;
    }

    public List<User> GetAllReaders()
    {
        return db.Users.ToList();
    }

    public User? GetLibrarian(int id)
    {
        // return db.Users.FirstOrDefault(librarian => librarian.Id == id);
        return null;
    }

    public User? GetLibrarian(string login)
    {
        // return db.Users.FirstOrDefault(librarian => librarian.Login == login);
        return null;
    }

    public List<User> GetAllLibrarians()
    {
        return db.Users.ToList();
    }

    public List<Book> GetBooks(string title, string? author)
    {
        var books = db.Books.Where(book => book.Title == title);
        if (author != null) books = books.Where(book => book.Author == author);
        return books.ToList();
    }

    public List<Book> GetAllBooks()
    {
        return db.Books.ToList();
    }

    public Book? GetBook(int id)
    {
        return db.Books.FirstOrDefault(book => book.BookId == id);
    }

    public List<BorrowedBook> GetBorrowedBooks(User reader)
    {
        return db.BorrowedBooks.Where(borrowedBook => borrowedBook.ReaderId == reader.Id).ToList();
    }

    public List<ReservedBook> GetReservedBooks(User reader)
    {
        return db.ReservedBooks.Where(reservedBook => reservedBook.ReaderId == reader.Id).ToList();
    }

    public ReservedBook? GetReservedBook(User reader, Book book)
    {
        return db.ReservedBooks.FirstOrDefault(reservedBook =>
            reservedBook.ReaderId == reader.Id && reservedBook.BookId == book.BookId);
    }
    
    public bool LoginAlreadyUsed(string login)
    {
        // return db.Users.Any(r => r.Login == login) || db.Users.Any(l => l.Login == login);
        return true;
    }
    
    public bool PasswordAlreadyUsed(string password)
    {
        // var passwordHasher = new PasswordHasher<User>();
        // var passwordHash = passwordHasher.HashPassword(null!, password);
        // return db.Users.Any(r => r.Hash == passwordHash)
        //        || db.Users.Any(l => l.Hash == passwordHash);
        return true;
    }
}