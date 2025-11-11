using Core.Domain.Locations;
using Core.Repositories.Locations;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Persistence.Repositories.Locations
{
    public class CorralRepository : Repository<Corral>, ICorralRepository
    {
        public CorralRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Corral>> GetAllWithRanchAsync()
        {
            return await Context.Corrals
                .Include(c => c.Ranch) 
                .ToListAsync();
        }

        public async Task<Corral> GetByIdWithRanchAsync(Guid id)
        {
            return await Context.Corrals
                .Include(c => c.Ranch)
                .SingleOrDefaultAsync(c => c.IdCorral == id);
        }
    }
}