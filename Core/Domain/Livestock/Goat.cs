using System;

namespace Core.Domain.Livestock;

public class Goat : Animal
{
    public static readonly Guid SPECIES_ID = Guid.Parse("02");

    public decimal MilkProductionPerDay { get; set; }

    public Goat() : base(SPECIES_ID)
    {
    }

    public override string EmitSound() => "Balido beeeeee";
}