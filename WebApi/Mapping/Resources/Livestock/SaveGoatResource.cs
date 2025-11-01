namespace WebApi.Mapping.Resources.Livestock;

public class SaveGoatResource : SaveAnimalResource
{
    public decimal MilkProductionPerDay { get; set; }
}