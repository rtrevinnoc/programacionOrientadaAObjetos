namespace CartoLogger.Domain.Entities;

public class User
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

    public List<Map> Maps {get; private set;} = [];
    public List<Feature> Features {get; private set;} = [];
}
