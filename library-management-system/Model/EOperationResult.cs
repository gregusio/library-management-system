namespace library_management_system.Model;

public enum EOperationResult
{
    Success,
    DatabaseError,
    NoAvailableCopies,
    UnexpectedError,
    BorrowedBookLimitExceeded,
    ReservedBookLimitExceeded,
    RenewalLimitReached
}