using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Domain.Entities;

public enum FeatureType
{
    Feature,
    FeatureCollection
}

public class Feature : IEntity
{
    public int Id {get; set;}
    public required FeatureType Type {get; set;}
    public required string Name {get; set;}
    public required string Description {get; set;}
    public required string Geometry {get; set;}

    public int? MapId {get; set;}
    public Map? Map {get; private set;}

    public int? UserId {get; set;}
    public User? User {get; private set;}
}
