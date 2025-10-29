using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Management;
using Core.Repositories.Courses;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistence.Repositories.Courses;

public class CoursesRepository : Repository<Course>, ICoursesRepository
{
    public CoursesRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
    {
    }

    private ProgramacionOrientadaAObjetosContext ProgramacionOrientadaAObjetosContext => Context;
}