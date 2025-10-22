using WebApi.Mapping.Resources.Employees;

namespace WebApi.Mapping.Resources.Management;

public class ScheduleResource
{
    public required Guid Id { get; set; }
    public required TimeSpan Duration { get; set; }
    public required TeacherResource Teacher { get; set; }
    public required Guid TeacherId { get; set; }
    // public required Course Course { get; set; }
    public required Guid CourseId { get; set; }
    // public required Classroom Classroom { get; set; }
    public required Guid ClassroomId { get; set; }
}