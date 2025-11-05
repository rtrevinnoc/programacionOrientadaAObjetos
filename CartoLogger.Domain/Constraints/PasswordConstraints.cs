using System.Security.Cryptography;

namespace CartoLogger.Domain.Constraints;

public static class PasswordConstraints
{
    public const int minLength = 8;
    public const int maxLength = 30;

    public static bool IsValidPassword(string password, out string? err)
    {
        if (password.Length < minLength || password.Length > maxLength)
        {
            err = $"password must be between {minLength} and {maxLength}";
            return false;
        }
        if (!(password.Any(char.IsUpper) && password.Any(char.IsLower)))
        {
            err = "password must both uppercase and lowercase letters";
            return false;
        }
        if (!password.Any(char.IsDigit))
        {
            err = "password must contain at least one digit";
            return false;
        }
        err = null;
        return true;
    }

    public static string HashPassword(string password)
    {
        const int saltSize = 16;
        const int keySize = 32;
        const int iterations = 100000;

        using var algorithm = new Rfc2898DeriveBytes(
            password, saltSize, iterations, HashAlgorithmName.SHA256);

        byte[] salt = algorithm.Salt;
        byte[] hash = algorithm.GetBytes(keySize);

        return $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.');
        if (parts.Length != 3)
            throw new FormatException("Unexpected hash format");

        int iterations = int.Parse(parts[0]);
        byte[] salt = Convert.FromBase64String(parts[1]);
        byte[] hash = Convert.FromBase64String(parts[2]);

        using var algorithm = new Rfc2898DeriveBytes(
            password, salt, iterations, HashAlgorithmName.SHA256);

        byte[] hashToCompare = algorithm.GetBytes(hash.Length);

        return CryptographicOperations.FixedTimeEquals(hash, hashToCompare);
        
    }
}
