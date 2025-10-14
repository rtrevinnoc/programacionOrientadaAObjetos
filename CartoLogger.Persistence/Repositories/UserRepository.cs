using Microsoft.EntityFrameworkCore;

using CartoLogger.Domain.Entities;
using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Persistence.Repositories;

public class UserRepository(CartoLoggerDbContext context)
    : Repository<User>(context), IUserRepository
{
    public Task<User?> GetByName(string name)
    {
        return _context.Users.SingleOrDefaultAsync(u => u.Name == name);
    }

    public Task<User?> GetByEmail(string email)
    {
        return _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public Task LoadMaps(User user)
    {
        return _context.Entry(user).Collection(u => u.Maps).LoadAsync();
    }

    public Task LoadFeatures(User user)
    {
        return _context.Entry(user).Collection(u => u.Features).LoadAsync();
    }
}
