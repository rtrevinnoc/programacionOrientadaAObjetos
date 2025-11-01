namespace WebApi.Mapping.Resources.Livestock;

public class AnimalResource
{
    public required Guid IdRegistration { get; set; }
    public required int IdRanch { get; set; }
    public int? IdBreed { get; set; }
    public int IdSpecie { get; set; }
    public int Gender { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public string? Sound { get; set; }
}