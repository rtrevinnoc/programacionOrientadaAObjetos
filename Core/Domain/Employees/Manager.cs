using Core.Domain.Management;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Employees;

public class Manager : Employee
{
    public string Username { get; set; }
    public string Password { get; set; }

    public PasswordVerificationResult SignIn(PasswordHasher<object> hasher, string input)
    {
        return hasher.VerifyHashedPassword(null, Password, input);
    }
}