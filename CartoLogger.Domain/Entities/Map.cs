using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Domain.Entities;

public class LatLng
{
    public required double Lat { get; init; }
    public required double Lng { get; init; }
}

public class View {
    public required LatLng Center { get; set; }
    public required double Zoom { get; set; }
}

public class Map : IEntity
{
    public static class TitleConstraints
    {
        public const int minLength = 1;
        public const int maxLength = 255;

        public static bool IsValidTitle(string name, out string? err)
        {
            if(name.Length < minLength || name.Length > maxLength)
            {
                err = "title length must be between "
                   + $"{minLength} and {maxLength} characters";
                return false;
            }
            err = null;
            return true;
        }
    }

    public static class DescriptionConstraints
    {
        public const int maxLength = 255;

        public static bool IsValidDescription(string name, out string? err) {
            if(name.Length > maxLength) {
                err = $"description length cannot exceed {maxLength} characters";
                return false;
            }
            err = null;
            return true;
        }
    }

    public int Id { get; private set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public View View { get; set; } = DefaultView();
    
    public int? UserId {get; set;}
    public User? User { get; private set; }

    public ICollection<Feature> Features { get; private set; } = [];

    //Many to many User<->Maps
    public ICollection<UserFavoriteMap> FavoritedBy {get; private set;} = []; 

    public static View DefaultView() {
        return new View{
            Center = new LatLng {    
                Lat = 25.725194867753334,
                Lng = -100.31513482332231
            },
            Zoom = 10
        };
    }
}
