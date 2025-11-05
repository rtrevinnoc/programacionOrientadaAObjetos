namespace CartoLogger.Domain.Entities;

public class UserFavoriteMap
{
    public required int UserId { get; set; }
    public User? User { get; private set;}
    public required int MapId { get; set; }
    public Map? Map { get; private set; }
}
