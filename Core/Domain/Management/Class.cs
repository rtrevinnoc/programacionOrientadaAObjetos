using System;

namespace Core.Domain.Management;

public class Class
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Schedule Schedule { get; set; }
    public required string ScheduleId { get; set; }
}