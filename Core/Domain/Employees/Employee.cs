using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain.Documents;
using Microsoft.OData.Edm;

namespace Core.Domain.Employees;

public enum VideogamesClasification
{
    Everyone = 1,
    Teen = 2,
    Mature = 3
}
public class Videogames
{
    [Key]
    public Guid IdRegistration { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Gender { get; set; }

    [Required]
    public VideogamesClasification Clasification { get; set; }

    [Required]

    public Date ReleaseDate { get; set; }

    public decimal Price { get; set; }
}