using System.Collections.Generic;
using Core.Domain.Management;

namespace Core.Domain.Employees;

public class Prefect : Employee
{
    public List<Llave> LLaves { get; set; }
}