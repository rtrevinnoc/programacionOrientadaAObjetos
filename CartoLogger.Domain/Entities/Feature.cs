namespace CartoLogger.Domain.Entities;

public class Feature
{
    public int Id {get; init;}
    public required string Data {get; set;}

    public int? MapId {get; private set;}
    public Map? Map {get; init;}

    public int? UserId {get; private set;}
    public User? User {get; init;}
}
