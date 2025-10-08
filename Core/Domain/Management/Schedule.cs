
using System;
using System.Dynamic;
using System.Net.Mime;
using Core.Domain.Employees;

namespace Core.Domain.Management;

public class Schedule
{
    public required Guid Id { get; set; }
    public required TimeSpan Duration { get; set; }
    public required Class Class { get; set; }
    public required Guid ClassId { get; set; }
}