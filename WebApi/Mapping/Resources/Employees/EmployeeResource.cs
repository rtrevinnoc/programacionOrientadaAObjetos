using Core.Domain.Employees;

namespace WebApi.Mapping.Resources.Employees;

public class EmployeeResource
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}