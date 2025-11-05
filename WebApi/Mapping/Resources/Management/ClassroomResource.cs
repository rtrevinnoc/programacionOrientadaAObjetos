using System;
using System.Collections.Generic;
using System.Threading;

namespace WebApi.Mapping.Resources.Management;

public class ClassroomResource
{
    public required Guid Id { get; set; }
    public int Number { get; set; }
    public LlaveResource Llave { get; set; }
}