using System;

namespace Core.Domain.Livestock;

public class Horse : Animal
{
    public static readonly Guid SPECIES_ID = Guid.Parse("01");

    public int Speed { get; set; }

    public Horse() : base(SPECIES_ID)
    {
    }

    public override string EmitSound() => "Relincho hiiiiii";
}