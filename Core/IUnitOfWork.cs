using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Documents;
using Core.Repositories.Employees;
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

        #endregion

        #region Documents

        IDocumentsRepository Documents { get; }

        #endregion

        #region Management

        ISchedulesRepository Schedules { get; }

        #endregion

        int Complete();

        Task CompleteAsync();
    }
}