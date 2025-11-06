namespace WebApi.Mapping.Resources.People
{
    public class RancherResource
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
    }
}