using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Taxonomy;

namespace Core.Domain.Taxonomy
{
    public class Specie
    {
        public Specie(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Breeds = new List<Breed>();
        }

        public Specie()
        {
            Name = null!;
            
            Breeds = new List<Breed>();
        }

        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public List<Breed> Breeds { get; set; }
    }
}