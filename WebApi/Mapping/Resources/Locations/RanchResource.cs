namespace WebApi.Mapping.Resources.Locations
{
    public class RanchResource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
    }
}