using CartoLogger.Domain.Entities;

namespace CartoLogger.Domain.Interfaces;
public interface IUserRepository : IRepository<User>
{
    public Task<bool> ExistsWithName(string name);
    public Task<bool> ExistsWithEmail(string email);
    public Task<User?> GetByName(string name);
    public Task<User?> GetByEmail(string email);
    public Task<List<Map>> GetMapsById(int id);

    public Task LoadMaps(User user);
    public Task LoadFavoriteMaps(User user);
    public Task LoadFeatures(User user);

    public Task<bool> MapIsInFavorites(int id, int mapId);
    public Task AddMapToFavorites(int id, int mapId);
    public Task RemoveMapFromFavorites(int id, int mapId);
    public Task<List<Map>> GetFavoriteMapsById(int id);
}
