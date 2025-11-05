using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Domain;

public interface IUnitOfWork
{
    public IUserRepository Users {get;}
    public IMapRepository Maps {get;}
    public IFeatureRepository Features {get;}

    public Task<int> SaveChangesAsync();
}
