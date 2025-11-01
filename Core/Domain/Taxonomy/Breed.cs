namespace Core.Domain.Taxonomy
{
    public class Breed
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public int SpecieId { get; set; }
        public Specie? Specie { get; set; }
    }
}