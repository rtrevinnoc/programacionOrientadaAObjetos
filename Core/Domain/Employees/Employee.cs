using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Documents;

namespace Core.Domain.Employees;

public class EmpleadoTienda
{
    public required Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? Genero { get; set; }
    public string? RFC { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Puesto { get; set; } // Cajero, Vendedor, Almacenista, Gerente
    public decimal Salario { get; set; }
    public DateTime FechaContratacion { get; set; }
    public string? Turno { get; set; } // Matutino, Vespertino, Nocturno
    public List<Document> Documents { get; set; }
    public virtual TipoEmpleado TipoEmpleado { get; set; }
}

public enum TipoEmpleado
{
    Cajero,
    Vendedor,
    Almacenista,
    Gerente,
    Supervisor
}
