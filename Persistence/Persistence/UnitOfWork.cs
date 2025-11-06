using System;
using System.Threading.Tasks;
using Core;
using Core.Repositories.Livestock;
using Core.Repositories.Locations;
using Core.Repositories.People;
using Core.Repositories.Taxonomy;
using Persistence.Persistence.Repositories.Livestock;
using Persistence.Persistence.Repositories.Locations;
using Persistence.Persistence.Repositories.People;
using Persistence.Persistence.Repositories.Taxonomy; 

namespace Persistence.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgramacionOrientadaAObjetosContext _context;

        public ILivestockRepository Livestock { get; }
        public ISpecieRepository Species { get; }
        public IBreedRepository Breeds { get; }
        public IRanchRepository Ranches { get; }
        public IRancherRepository Ranchers { get; }
        public ICorralRepository Corrals { get; }

        public UnitOfWork(ProgramacionOrientadaAObjetosContext context)
        {
            _context = context;

            Livestock = new LivestockRepository(_context);
            Species = new SpecieRepository(_context);
            Breeds = new BreedRepository(_context);
            Ranches = new RanchRepository(_context);
            Ranchers = new RancherRepository(_context);
            Corrals = new CorralRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}