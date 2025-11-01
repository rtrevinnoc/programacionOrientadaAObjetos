namespace WebApi.Mapping.Resources.Livestock;

public abstract class SaveAnimalResource
{
    public required Guid IdRegistration { get; set; }
    public required int IdRanch { get; set; }
    public int Gender { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
}