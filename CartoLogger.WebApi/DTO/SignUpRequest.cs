using System.ComponentModel.DataAnnotations;

namespace CartoLogger.WebApi.DTO;

public class SignUpRequest
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}
