using System;
using Core.Domain;
using Core.Repositories;
using Core;
using System.Threading.Tasks;
using Core.Domain.Livestock;
using Persistence.Persistence.Repositories.Livestock;
using Core.Repositories.Livestock;

namespace Persistence.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgramacionOrientadaAObjetosContext _context;

        public UnitOfWork(ProgramacionOrientadaAObjetosContext context)
        {
            _context = context;
            Livestock = new LivestockRepository(_context);
        }

        #region Entities
        public ILivestockRepository Livestock { get; set; }

        #endregion

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}