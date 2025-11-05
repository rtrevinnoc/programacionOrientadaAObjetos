namespace CartoLogger.Domain.Constraints;

public static class EmailConstaints
{
    public const int minLength = 8; 
    public const int maxLength = 254;

    public static bool IsValidEmail(string email, out string? err)
    {
        if(email.Length < minLength || email.Length > maxLength)
        {
            err = $"email length must be between {minLength} and {maxLength}";
            return false;
        }
        if(!email.Contains('@'))
        {
            err = "invalid email format";
            return false;
        }
        err = null;
        return true; 
    }
}
