using Core.Domain.Taxonomy;
using Core.Repositories.Taxonomy;
using Persistence.Persistence;
using Persistence.Persistence.Repositories;

namespace Persistence.Persistence.Repositories.Taxonomy
{
    public class BreedRepository : Repository<Breed>, IBreedRepository
    {
        public BreedRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }
    }
}