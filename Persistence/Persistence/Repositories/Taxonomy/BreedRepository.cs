using Core.Domain.Taxonomy;
using Core.Repositories.Taxonomy;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace Persistence.Persistence.Repositories.Taxonomy
{
    public class BreedRepository : Repository<Breed>, IBreedRepository
    {
        public BreedRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Breed>> GetAllWithSpecieAsync()
        {
            return await Context.Breeds
                .Include(b => b.Specie)
                .ToListAsync();
        }

        public async Task<Breed> GetByIdWithSpecieAsync(Guid id)
        {
            return await Context.Breeds
                .Include(b => b.Specie)
                .SingleOrDefaultAsync(b => b.Id == id);
        }
    }
}