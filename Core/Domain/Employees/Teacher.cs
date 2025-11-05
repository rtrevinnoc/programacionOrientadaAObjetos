using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Documents;
using Core.Domain.Management;

namespace Core.Domain.Employees;

public class Teacher : Employee
{
    public Teacher() : base()
    {
        Schedules = new List<Schedule>();
    }

    public List<Schedule> Schedules { get; set; }
}