using System;

namespace Core.Domain.Management;

public class Key
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}