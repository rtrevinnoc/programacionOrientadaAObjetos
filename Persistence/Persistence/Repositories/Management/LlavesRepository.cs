using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Management;
using Core.Repositories.Llaves;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Llaves;

public class LlavesRepository : Repository<Llave>, ILlavesRepository
{
    public LlavesRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}