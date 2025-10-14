namespace CartoLogger.WebApi.DTO.Http;

public class SignUpRequest
{
    public required string Username {get; set;}
    public required string Email {get; set;}
    public required string Password {get; set;}
}
