using System.Collections.Generic;
using Core.Domain.Management;

namespace Core.Domain.Employees;

public class Prefect : Employee
{
    public EmployeeType EmployeeType { get; } = EmployeeType.Prefect;
    public List<Key> Keys { get; set; }
}