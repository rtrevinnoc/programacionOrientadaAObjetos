using Core.Domain.Livestock;
using Core.Repositories.Livestock;

namespace Persistence.Persistence.Repositories.Livestock
{
    public class LivestockRepository : Repository<Animal>, ILivestockRepository
    {
        public LivestockRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }
    }
}