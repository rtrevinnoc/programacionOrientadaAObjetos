using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Livestock;

namespace Core.Domain.Taxonomy
{
    public class Breed
    {
        public Breed(string name, Guid specieId)
        {
            Id = Guid.NewGuid();
            Name = name;
            SpecieId = specieId;
            Animals = new List<Animal>();
        }

        public Breed()
        {
            Name = null!; 
            
            Animals = new List<Animal>();
        }

        public Guid Id { get; set; }
        
        [Required] 
        public string Name { get; set; }
        
        public Guid SpecieId { get; set; }
        public Specie Specie { get; set; } = null!;
        public List<Animal> Animals { get; set; }
    }
}