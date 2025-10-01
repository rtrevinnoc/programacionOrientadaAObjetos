using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Employees;
using Core.Repositories.Employees;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Employees;

public class EmployeesRepository : Repository<Employee>, IEmployeesRepository
{
    public EmployeesRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}