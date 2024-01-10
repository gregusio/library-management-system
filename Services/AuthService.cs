using library_management_system.Database;
namespace library_management_system.Services;

public class AuthService
{
    public BasicPersonInfo? User { get; set; }

    public bool IsLibrarian()
    {
        return User is Librarian;
    }

    public bool IsReader()
    {
        return User is Reader;
    }

    public bool IsLoggedIn()
    {
        return User != null;
    }
}
