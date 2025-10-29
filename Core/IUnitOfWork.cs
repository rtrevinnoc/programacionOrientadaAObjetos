using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Livestock;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Management
        #endregion

        #region Employees

        ILivestockRepository Livestock { get; }

        #endregion

        int Complete();

        Task CompleteAsync();
    }
}