namespace WebApi.Mapping.Resources.Locations
{
    public class CorralResource
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Capacity { get; set; }
    }
}