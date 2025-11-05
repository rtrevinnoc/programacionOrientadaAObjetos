using System;
using System.Collections.Generic;

namespace Core.Domain.Management;

public class Course
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Schedule> Schedules { get; set; }
}