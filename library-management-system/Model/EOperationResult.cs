using BlazorBootstrap;

namespace library_management_system.Model;

public enum EOperationResult
{
    Success,
    DatabaseError,
    NoAvailableCopies,
    UnexpectedError,
    BorrowedBookLimitExceeded,
    ReservedBookLimitExceeded,
    RenewalLimitReached,
    BookNotReserved,
    BookReserved
}

public static class OperationResultExtensions
{
    public static string GetMessage(this EOperationResult result)
    {
        return result switch
        {
            EOperationResult.Success => "Success",
            EOperationResult.DatabaseError => "Database error",
            EOperationResult.NoAvailableCopies => "No available copies",
            EOperationResult.UnexpectedError => "Unexpected error",
            EOperationResult.BorrowedBookLimitExceeded => "Borrowed book limit exceeded!",
            EOperationResult.ReservedBookLimitExceeded => "Reserved book limit exceeded!",
            EOperationResult.RenewalLimitReached => "Renewal limit reached",
            EOperationResult.BookReserved => "Book is already reserved",
            _ => "Unknown error"
        };
    }

    public static ToastType GetToastType(this EOperationResult result)
    {
        return result switch
        {
            EOperationResult.Success => ToastType.Success,
            EOperationResult.DatabaseError => ToastType.Warning,
            EOperationResult.NoAvailableCopies => ToastType.Info,
            EOperationResult.UnexpectedError => ToastType.Warning,
            EOperationResult.BorrowedBookLimitExceeded => ToastType.Info,
            EOperationResult.ReservedBookLimitExceeded => ToastType.Info,
            EOperationResult.RenewalLimitReached => ToastType.Info,
            EOperationResult.BookReserved => ToastType.Info,
            _ => ToastType.Info
        };
    }
}