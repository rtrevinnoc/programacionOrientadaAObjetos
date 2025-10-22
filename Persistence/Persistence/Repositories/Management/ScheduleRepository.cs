using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Management;
using Core.Repositories.Schedules;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Schedules;

public class SchedulesRepository : Repository<Schedule>, ISchedulesRepository
{
    public SchedulesRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}