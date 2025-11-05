
using System;
using System.Dynamic;
using System.Net.Mime;
using Core.Domain.Employees;

namespace Core.Domain.Management;

public class Schedule
{
    public required Guid Id { get; set; }
    public required TimeSpan Duration { get; set; }
    public required Teacher Teacher { get; set; }
    public required Guid TeacherId { get; set; }
    public required Course Course { get; set; }
    public required Guid CourseId { get; set; }
    public required Classroom Classroom { get; set; }
    public required Guid ClassroomId { get; set; }
}