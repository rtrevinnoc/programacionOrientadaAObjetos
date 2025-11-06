using Core.Domain.Taxonomy;
using Core.Repositories.Taxonomy;
using Persistence.Persistence;
using Persistence.Persistence.Repositories;

namespace Persistence.Persistence.Repositories.Taxonomy
{
    public class SpecieRepository : Repository<Specie>, ISpecieRepository
    {
        public SpecieRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }
    }
}