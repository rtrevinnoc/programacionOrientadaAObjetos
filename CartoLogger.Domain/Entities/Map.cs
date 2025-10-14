namespace CartoLogger.Domain.Entities;

public class Map
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
            return false;
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

    public int Id {get; private set;}
    public required string Title {get; set;}
    public required string Description {get; set;}
    
    public int? UserId {get; private set;}
    public User? User {get; init;}

    public List<Feature> Features {get; private set;} = [];
}
