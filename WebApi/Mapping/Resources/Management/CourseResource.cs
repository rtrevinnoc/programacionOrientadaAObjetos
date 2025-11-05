using System;
using System.Collections.Generic;

namespace WebApi.Mapping.Resources.Management;

public class CourseResource
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ScheduleResource> Schedules { get; set; }
}