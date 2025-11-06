using Core.Domain.Locations;
using Core.Repositories.Locations;

namespace Persistence.Persistence.Repositories.Locations
{
    public class CorralRepository : Repository<Corral>, ICorralRepository
    {
        public CorralRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }
    }
}