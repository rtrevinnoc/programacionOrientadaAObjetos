using System.Collections.Generic;
using Core.Domain.Livestock;
using Core.Domain.People;

namespace Core.Domain.Locations

{
    public class Ranch
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }

        public List<Animal> Animals { get; set; } = new();
        public Rancher Rancher { get; set; } = null!;
    }
}