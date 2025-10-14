using CartoLogger.Domain.Entities;

namespace CartoLogger.Domain.Interfaces;
public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetByName(string name);
    public Task<User?> GetByEmail(string email);
    public Task LoadMaps(User user);
}
