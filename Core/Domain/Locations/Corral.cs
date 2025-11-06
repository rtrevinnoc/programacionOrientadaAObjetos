using Core.Domain.Livestock;
using System;
using System.Collections.Generic;

namespace Core.Domain.Locations
{
    public class Corral
    {
        public Guid IdCorral { get; set; }
        public required string Name { get; set; }
        public required int Capacity { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}