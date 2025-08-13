using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Employees;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Management
        #endregion

        #region Employees

        IEmployeesRepository Employees { get; }

        #endregion

        int Complete();

        Task CompleteAsync();
    }
}