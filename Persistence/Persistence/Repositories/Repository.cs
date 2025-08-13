using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Repositories;

namespace Persistence.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProgramacionOrientadaAObjetosContext Context;

        public Repository(ProgramacionOrientadaAObjetosContext context)
        {
            Context = context;
        }

        public TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Context.Set<TEntity>().ToListAsync();
        }
    }
}