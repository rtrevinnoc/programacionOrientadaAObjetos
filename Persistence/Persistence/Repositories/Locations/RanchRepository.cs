using Core.Domain.Locations;
using Core.Repositories.Locations;
using Persistence.Persistence;
using Persistence.Persistence.Repositories;

namespace Persistence.Persistence.Repositories.Locations
{
    public class RanchRepository : Repository<Ranch>, IRanchRepository
    {
        public RanchRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }
    }
}