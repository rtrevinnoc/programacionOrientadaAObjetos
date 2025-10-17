namespace Core.Domain.Employees;

public class EmpleadoPrincipal
{
    public required Guid Id { get; set; }
    public required string NombreCompleto { get; set; }
    public string? Sexo { get; set; }
    public string? CURP { get; set; }
    public string? RFC { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Puesto { get; set; }
    public decimal Salario { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string? Turno { get; set; }
    public List<Document> Documents { get; set; }
    public virtual CategoriaEmpleado CategoriaEmpleado { get; set; }
    public virtual NivelEmpleado NivelEmpleado { get; set; }
}

public enum CategoriaEmpleado
{
    Administrativo,
    Docente,
    Servicios,
    Seguridad,
    Direccion
}

public enum NivelEmpleado
{
    Practicante,
    Empleado,
    Supervisor,
    Gerente,
    Director
}
