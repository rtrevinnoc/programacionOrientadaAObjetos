namespace WebApi.Mapping.Resources.Taxonomy
{
    public class SpecieResource
    {
        public int Id { get; set; }
        public required string CommonName { get; set; }
        public required string? ScientificName { get; set; }

        public int SpecieId { get; set; }
    }
}