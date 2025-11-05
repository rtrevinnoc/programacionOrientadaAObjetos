using System.Text.Json.Serialization;
using CartoLogger.Domain.Entities;

namespace CartoLogger.WebApi.DTO;


public class UpdateUserRequest
{
    public string? Name {get; set;}
    public string? Email {get; set;}
}

public class UserDto {
    public required int Id {get; set;}
    public required string Name {get; set;}
    public required string Email {get; set;}

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MapDto>? Maps {get; set;}

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<MapDto>? FavoriteMaps {get; set;}

    public static UserDto FromUser(
        User user,
        bool maps = false,
        bool favoriteMaps = false
    ) {
        return new UserDto {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Maps = maps ?
                user.Maps.Select(
                    map => MapDto.FromMap(
                        map,
                        features: false
                    )
                ) : null,
            FavoriteMaps = favoriteMaps ?
                user.FavoriteMaps
                    .Where(ufm => ufm.Map is not null)
                    .Select(
                        ufm => MapDto.FromMap(
                            ufm.Map!,
                            features: false
                    ) 
                ) : null
        };
    }
}
