using Core.Domain.Management;

namespace Core.Domain.Employees;

public class Manager : Employee
{
    public string Username { get; set; }
    public string Password { get; set; }
}