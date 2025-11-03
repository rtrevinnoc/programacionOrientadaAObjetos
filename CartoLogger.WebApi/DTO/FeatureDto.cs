using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CartoLogger.Domain.Entities;

namespace CartoLogger.WebApi.DTO;

public class Properties
{ 
    public required string Name {get; set;}
    public required string Description {get; set;}
}

public class PartialProperties
{
    public string? Name {get; set;}
    public string? Description {get; set;}
}


public class GeoJsonFeature
{
    public required string Type { get; set; }
    public required Properties Properties { get; set; }
    public required JsonNode Geometry { get; set; }

    public static string GetStrFromType(FeatureType type)
    {
        return type switch
        {
            FeatureType.Feature => "Feature",
            FeatureType.FeatureCollection => "FeatureCollection",
            _ => throw new ArgumentException("invalid feature type")
        };
    }

    public static FeatureType GetTypeFromStr(string str)
    {
        return str switch
        {
            "Feature" => FeatureType.Feature,
            "FeatureCollection" => FeatureType.FeatureCollection,
            _ => throw new ArgumentException("invalid feature string")
        };
    } 
}

public class PartialGeoJsonFeature
{
    public string? Type {get; set;}
    public PartialProperties? Properties {get; set;}
    public JsonNode? Geometry { get; set; }
}


public class CreateFeatureRequest
{
    [Required]
    public required int? UserId {get; set;}
    [Required]
    public required int? MapId {get; set;}
    [Required]
    [JsonPropertyName("geojson")]
    public required GeoJsonFeature GeoJson {get; set;}

    public static Feature ToFeature(CreateFeatureRequest req)
    {
        return new Feature
        {
            UserId = req.UserId,
            MapId = req.MapId,
            Type = GeoJsonFeature.GetTypeFromStr(req.GeoJson.Type),
            Name = req.GeoJson.Properties.Name,
            Description = req.GeoJson.Properties.Description,
            Geometry = req.GeoJson.Geometry.ToJsonString()
        };
    }
}


public class UpdateFeatureRequest
{
    [JsonPropertyName("geojson")]
    public PartialGeoJsonFeature? GeoJson {get; set;}
}


public class FeatureDto
{
    public required int Id {get; set;}
    public required int? UserId { get; set; }
    public required int? MapId { get; set; }
    [JsonPropertyName("geojson")]
    public required GeoJsonFeature GeoJson { get; set; }

    public static FeatureDto FromFeature(Feature feature)
    {
        JsonNode? geometryNode = JsonNode.Parse(feature.Geometry);
        //might cause data to not show up if inserted direcly into db
        geometryNode ??= new JsonObject();
        
        return new FeatureDto
        {
            Id = feature.Id,
            UserId = feature.UserId,
            MapId = feature.MapId,
            GeoJson = new GeoJsonFeature {
                Type = GeoJsonFeature.GetStrFromType(feature.Type),
                Properties = new Properties {
                    Name = feature.Name,
                    Description = feature.Description
                },
                Geometry = geometryNode
            }     
        };
    }
}
