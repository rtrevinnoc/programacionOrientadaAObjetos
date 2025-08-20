using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Employees;

public class Employee
{
    [Key]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Sexo { get; set; }
    public string? CURP { get; set; }
    public int? TelefonoCasa { get; set; }
    public string? Correo { get; set; }
}