using System.ComponentModel.DataAnnotations;

namespace CartoLogger.WebApi.DTO.Http;

public class LoginRequest 
{
    [Required]
    public required string Identity {get; set;} //username or email
    [Required]
    public required string Password {get; set;}
}
