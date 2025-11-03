using CartoLogger.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartoLogger.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
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

    public Task<bool> Exists(int id) {
        return _context.Set<TEntity>().AnyAsync(e => e.Id == id);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }


    public void AddRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }


    public Task RemoveById(int id) {
        return _context.Set<TEntity>().Where(e => e.Id == id).ExecuteDeleteAsync();
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
