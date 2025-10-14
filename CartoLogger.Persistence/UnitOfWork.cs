using CartoLogger.Domain;
using CartoLogger.Domain.Interfaces;
using CartoLogger.Persistence.Repositories;

namespace CartoLogger.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly CartoLoggerDbContext _context;

    public IUserRepository Users {get;}
    public IMapRepository Maps {get;}
    public IFeatureRepository Features {get;}

    public UnitOfWork(CartoLoggerDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        Maps = new MapRepository(_context);
        Features = new FeatureRepository(_context);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

}
