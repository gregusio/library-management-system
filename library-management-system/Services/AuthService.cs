using library_management_system.Data;

namespace library_management_system.Services;

public class AuthService
{
    public User? User { get; set; }

    public bool IsLibrarian()
    {
        return true;
    }

    public bool IsAdmin()
    {
        return true;
    }

    public bool IsReader()
    {
        return true;
    }

    public bool IsLoggedIn()
    {
        return User != null;
    }
}