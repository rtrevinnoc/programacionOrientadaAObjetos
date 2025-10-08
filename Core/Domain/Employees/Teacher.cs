using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Documents;
using Core.Domain.Management;

namespace Core.Domain.Employees;

public class Teacher : Employee
{
    public List<Schedule> Schedules { get; set; }

    public EmployeeType EmployeeType { get; } = EmployeeType.Teacher;
}