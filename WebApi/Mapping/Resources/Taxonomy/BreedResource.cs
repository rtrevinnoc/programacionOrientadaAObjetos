namespace WebApi.Mapping.Resources.Taxonomy
{
    public class BreedResource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required SpecieResource Specie { get; set; }
    }
}