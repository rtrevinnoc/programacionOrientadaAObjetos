namespace Core.Domain.Livestock;

public class Horse : Animal
{
    public const int SPECIES_ID = 1;
    public decimal MaxSpeed { get; set; }

    public Horse() : base(SPECIES_ID)
    {
    }
    public override string EmitSound() => "Relincho hiiiihiii";
}