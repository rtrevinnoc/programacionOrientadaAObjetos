using CartoLogger.Domain.Interfaces;

namespace CartoLogger.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly CartoLoggerDbContext _context;

    protected Repository(CartoLoggerDbContext context)
    {
        _context = context;
    }


    public Task<TEntity?> GetById(int id)
    {
        return _context.Set<TEntity>().FindAsync(id).AsTask();
    }


    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }


    public void AddRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }


    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }


    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

}
