using Core.Domain.Livestock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Locations
{
    public class Corral
    {
public Corral()
        {
            IdCorral = Guid.NewGuid();
            Name = null!;
            Animals = new List<Animal>();
        }
        
        public Guid IdCorral { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required] // <-- 3. AÑADIDO
        public int Capacity { get; set; }
        
        public ICollection<Animal> Animals { get; set; }

        public Guid RanchId { get; set; }
        public Ranch Ranch { get; set; } = null!;
    }
}