using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Classrooms;
using Core.Repositories.Courses;
using Core.Repositories.Documents;
using Core.Repositories.Employees;
using Core.Repositories.Llaves;
using Core.Repositories.Schedules;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Management
        #endregion

        #region Employees

        IEmployeesRepository Employees { get; }
        ITeachersRepository Teachers { get; }

        IManagersRepository Managers { get; }

        #endregion

        #region Documents

        IDocumentsRepository Documents { get; }

        #endregion

        #region Management

        ISchedulesRepository Schedules { get; }
        ICoursesRepository Courses { get; }
        IClassroomsRepository Classrooms { get; }
        ILlavesRepository Llaves { get; set;  }

        #endregion

        int Complete();

        Task CompleteAsync();
    }
}