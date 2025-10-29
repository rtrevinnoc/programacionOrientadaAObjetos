using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Livestock;

public enum AnimalSpecies
{
    Bovine = 1,
    Equine = 2,
    Caprine = 3
}

public enum AnimalGender
{
    Male = 1,
    Female = 2
}

public class Animal
{
    [Key]
    public Guid IdRegistration { get; set; } 

    [Required]
    public required string ActualRanch { get; set; } 

    [Required]
    public required string Breed { get; set; } 
    
    [Required]
    public AnimalSpecies Species { get; set; } 

    [Required]  
    public AnimalGender Gender { get; set; } 

    public int Age { get; set; }

    public decimal Weight { get; set; } 
}

