namespace CartoLogger.WebApi.DTO.Http;

public class LoginResponse 
{
    public required UserDto User {get; set;}
    public required IEnumerable<MapDto> Maps {get; set;}
}
