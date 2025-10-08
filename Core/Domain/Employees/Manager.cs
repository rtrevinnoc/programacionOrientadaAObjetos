using Core.Domain.Management;

namespace Core.Domain.Employees;

public class Manager : Employee
{
    public EmployeeType EmployeeType { get; } = EmployeeType.Manager;
}