using System;
using Core.Domain.Employees;

namespace WebApi.Mapping.Resources.Management;

public class LlaveResource
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}