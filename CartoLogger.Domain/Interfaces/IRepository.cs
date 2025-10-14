namespace CartoLogger.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> GetById(int id);
    public void Add(TEntity entity);
    public void AddRange(IEnumerable<TEntity> entities);
    public void Remove(TEntity entity);
    public void RemoveRange(IEnumerable<TEntity> entities);
}
