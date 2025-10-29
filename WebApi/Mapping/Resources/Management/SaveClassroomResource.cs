using System;
using System.Collections.Generic;
using System.Threading;

namespace WebApi.Mapping.Resources.Management;

public class SaveClassroomResource
{
    public required int Number { get; set; }

    public required SaveLlaveResource Llave { get; set; }
}

public class SaveLlaveResource
{
    public required string Name { get; set; }
    public Guid? PrefectId { get; set; }
}