using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Locations;
using Core.Domain.Taxonomy;

namespace Core.Domain.Livestock;

public enum AnimalGender
{
    Male = 1,
    Female = 2
}

public abstract class Animal
{
    [Key]
    public Guid IdRegistration { get; set; } 

    [Required]
    public required Guid IdRanch { get; set; }
    public Ranch? Ranch { get; set; } 

    public Guid? IdBreed { get; set; }
    public Breed? Breed { get; set; }
    
    [Required]
    public Guid IdSpecie { get; set; }
    public Specie? Specie { get; set; }

    public AnimalGender Gender { get; set; } 

    public int Age { get; set; }

    public decimal Weight { get; set; }
    protected Animal(Guid idSpecie)
    {
        IdSpecie = idSpecie;
    }
    public Guid? CorralId { get; set; }
    public Core.Domain.Locations.Corral? Corral { get; set; }
    public abstract string EmitSound();
}

