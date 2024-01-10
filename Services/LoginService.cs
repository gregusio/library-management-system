using System.Security.Cryptography;
using System.Text;

namespace library_management_system.Services;

public class LoginService
{
    public string HashPassword(string password)
    {
        var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }
    
    public bool CheckPassword(string password, string passwordHash)
    {
        return HashPassword(password) == passwordHash;
    }
}