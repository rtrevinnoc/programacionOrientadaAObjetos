using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Employees;
using Core.Repositories.Employees;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Employees;

public class TeachersRepository : Repository<Teacher>, ITeachersRepository
{
    public TeachersRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}