using System.Collections.Generic;
using Core.Domain.Livestock;

namespace Core.Domain.Taxonomy
{
    public class Specie
    {
        public int Id { get; set; }
        public required string CommonName { get; set; }
        public required string? ScientificName { get; set; }

        public List<Breed> Breeds { get; set; } = new();
        public List<Animal> Animals { get; set; } = new();
    }
}