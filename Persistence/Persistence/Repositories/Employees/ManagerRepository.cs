using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Employees;
using Core.Repositories.Employees;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Employees;

public class ManagersRepository : Repository<Manager>, IManagersRepository
{
    public ManagersRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;

    public Manager GetManagerByUsername(string username)
    {
        var managers = ProgramacionOrientadaAObjetosContext.Managers.Where(m => m.Username == username);
        return managers.Single();
    }
}