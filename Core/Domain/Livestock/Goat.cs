namespace Core.Domain.Livestock;

public class Goat : Animal
{
    public const int SPECIES_ID = 2;
    public decimal MilkProductionPerDay { get; set; }

    public Goat() : base(SPECIES_ID)
    {
    }
    public override string EmitSound() => "Balido beeeeee";
}