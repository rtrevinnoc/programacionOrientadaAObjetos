namespace WebApi.Mapping.Resources.Livestock;

public class SaveHorseResource : SaveAnimalResource
{
    public decimal MaxSpeed { get; set; }
}