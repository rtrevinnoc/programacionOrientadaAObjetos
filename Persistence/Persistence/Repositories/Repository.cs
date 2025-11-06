using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Repositories; // <-- El 'using' para IRepository
using Microsoft.EntityFrameworkCore; // <-- El 'using' para EntityFramework
using Persistence.Persistence; // <-- El 'using' para tu Context

namespace Persistence.Persistence.Repositories
{
    // Implementa la interfaz IRepository<TEntity>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Tu variable de Contexto
        protected readonly ProgramacionOrientadaAObjetosContext Context; 

        public Repository(ProgramacionOrientadaAObjetosContext context)
        {
            Context = context;
        }

        // --- Implementación de todos los métodos de tu interfaz ---

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

        // Coincide con tu interfaz (Task<List<TEntity>>)
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            // Añadido .ToList() para que coincida con el comportamiento síncrono
            return Context.Set<TEntity>().Where(predicate).ToList(); 
        }
        
        // --- ESTE ES UNO DE LOS QUE FALTABA ---
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        // --- ESTE TAMBIÉN FALTABA ---
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        // Coincide con tu interfaz (void AddRange)
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
    }
}