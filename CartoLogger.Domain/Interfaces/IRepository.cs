namespace CartoLogger.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public Task<TEntity?> GetById(int id);
    public Task<bool> Exists(int id);
    public void Add(TEntity entity);
    public void AddRange(IEnumerable<TEntity> entities);
    public Task RemoveById(int id);
    public void Remove(TEntity entity);
    public void RemoveRange(IEnumerable<TEntity> entities);
}
