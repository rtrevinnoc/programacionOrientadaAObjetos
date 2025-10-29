using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Livestock;
using Core.Repositories.Livestock;

namespace Persistence.Persistence.Repositories.Livestock;

public class LivestockRepository : Repository<Animal>, ILivestockRepository
{
    public LivestockRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}