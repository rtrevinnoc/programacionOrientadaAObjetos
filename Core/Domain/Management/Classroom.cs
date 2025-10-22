using System;
using System.Collections.Generic;
using System.Threading;

namespace Core.Domain.Management;

public class Classroom
{
    public required Guid Id { get; set; }
    public required int Number { get; set; }
    public List<Schedule> Schedules { get; set; }
    public Llave Llave { get; set; }
}