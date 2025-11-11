using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Livestock;
using Core.Domain.People;

namespace Core.Domain.Locations
{
    public class Ranch
    {
        public Ranch(Guid id, string name, string location, Guid rancherId)
        {
            Id = id;
            Name = name;
            Location = location;
            RancherId = rancherId;
            Animals = new List<Animal>();
        }

        public Ranch()
        {
            Name = null!; 
            Location = null!;
            
            Animals = new List<Animal>();
        }
        

        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
        
        public Guid RancherId { get; set; }

        public List<Animal> Animals { get; set; }
        public Rancher Rancher { get; set; } = null!;
    }
}