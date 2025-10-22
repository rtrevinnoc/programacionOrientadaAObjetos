using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Documents;

namespace Core.Domain.Employees;

public class Employee
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Sexo { get; set; }
    public string? CURP { get; set; }
    public int? TelefonoCasa { get; set; }
    public string? Correo { get; set; }
    public List<Document> Documents { get; set; }
}