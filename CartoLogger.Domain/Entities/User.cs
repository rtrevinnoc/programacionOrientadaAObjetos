using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Domain.Entities;

public class User : IEntity
{
    public static class NameConstraints
    {   
        public const int minLength = 4;
        public const int maxLength = 30;

        public static bool IsValidName(string name, out string? err)
        {
            if(name.Length < minLength || name.Length > maxLength)
            {
                err = $"name length must be between {minLength} and {maxLength}";
                return false;
            }
            err = null;
            return true; 
        }
    }

    public int Id {get; private set;}
    public required string Name {get; set;}
    public required string Email {get; set;}
    public required string PasswordHash {get; init;}

    public ICollection<Map> Maps {get; private set;} = [];
    public ICollection<Feature> Features {get; private set;} = [];

    //Many to many User<->Maps
    public ICollection<UserFavoriteMap> FavoriteMaps {get; private set;} = []; 
}
