using Core.Domain.Locations;
using Core.Repositories.Locations;
using Microsoft.EntityFrameworkCore; 
using Persistence.Persistence;
using Persistence.Persistence.Repositories;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks; 

namespace Persistence.Persistence.Repositories.Locations
{
    public class RanchRepository : Repository<Ranch>, IRanchRepository
    {
        public RanchRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ranch>> GetAllWithRancherAsync()
        {
            return await Context.Ranches
                .Include(r => r.Rancher)
                .ToListAsync();
        }

        public async Task<Ranch> GetByIdWithRancherAsync(Guid id)
        {
            return await Context.Ranches
                .Include(r => r.Rancher)
                .SingleOrDefaultAsync(r => r.Id == id);
        }
    }
}