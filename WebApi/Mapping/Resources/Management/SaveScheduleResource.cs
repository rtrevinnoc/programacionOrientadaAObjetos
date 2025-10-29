namespace WebApi.Mapping.Resources.Management;

public class SaveScheduleResource
{
    public required int Duration { get; set; }
    public required Guid CourseId { get; set; }
    public required Guid ClassroomId { get; set; }
}