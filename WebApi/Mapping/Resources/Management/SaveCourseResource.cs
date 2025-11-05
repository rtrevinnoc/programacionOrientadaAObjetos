using System;
using System.Collections.Generic;

namespace WebApi.Mapping.Resources.Management;

public class SaveCourseResource
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
}