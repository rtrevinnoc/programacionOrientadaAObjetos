using Microsoft.EntityFrameworkCore;

using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Persistence.Repositories;

public class UserRepository(CartoLoggerDbContext context)
    : Repository<User>(context), IUserRepository
{

    public Task<bool> ExistsWithName(string name)
    {
        return _context.Users
            .AnyAsync(u => u.Name == name);
    }

    public Task<bool> ExistsWithEmail(string email)
    {
        return _context.Users
            .AnyAsync(u => u.Email == email);
    }

    public Task<User?> GetByName(string name)
    {
        return _context.Users
            .SingleOrDefaultAsync(u => u.Name == name);
    }

    public Task<User?> GetByEmail(string email)
    {
        return _context.Users
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public Task<List<Map>> GetMapsById(int id)
    {
       return _context.Maps
            .Where(m => m.UserId == id)
            .ToListAsync();
    }



    public Task LoadMaps(User user)
    {
        return _context.Entry(user)
            .Collection(u => u.Maps)
            .LoadAsync();
    }

    //Many-to-many intermediate table load
    public Task LoadFavoriteMaps(User user) {
        return _context.Entry(user)
            .Collection(u => u.FavoriteMaps)
            .Query()
            .Include(f => f.Map)
            .LoadAsync();
    }

    public Task LoadFeatures(User user)
    {
        return _context.Entry(user)
            .Collection(u => u.Features)
            .LoadAsync();
    }



    public Task<bool> MapIsInFavorites(int id, int mapId) {
        return _context.UserFavoriteMaps.AnyAsync(
            ufm => ufm.UserId == id && ufm.MapId == mapId
        );
    }

    public Task AddMapToFavorites(int id, int mapId)
    {
        return _context.UserFavoriteMaps.AddAsync(
            new UserFavoriteMap
            {
                UserId = id,
                MapId = mapId
            }
        ).AsTask(); 
    }
    
    public Task RemoveMapFromFavorites(int id, int mapId) {
        return _context.UserFavoriteMaps
                       .Where(ufm => ufm.UserId == id && ufm.MapId == mapId)
                       .ExecuteDeleteAsync();
    }

    public Task<List<Map>> GetFavoriteMapsById(int id)
    {
        return _context.Maps
                       .Where(m => m.FavoritedBy.Any(ufm => ufm.UserId == id))
                       .ToListAsync();
    }
}
