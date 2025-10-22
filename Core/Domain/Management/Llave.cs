using System;
using Core.Domain.Employees;

namespace Core.Domain.Management;

public class Llave
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Prefect Prefect { get; set; }
    public required Guid PrefectId { get; set; }
    public required Classroom Classroom { get; set; }
    public required Guid ClassroomId { get; set; }
}