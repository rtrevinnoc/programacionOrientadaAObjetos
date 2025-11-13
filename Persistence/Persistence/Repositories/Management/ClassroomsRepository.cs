using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Management;
using Core.Repositories.Classrooms;
using Core.Repositories.Courses;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Classrooms;

public class ClassroomsRepository : Repository<Classroom>, IClassroomsRepository
{
    public ClassroomsRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}