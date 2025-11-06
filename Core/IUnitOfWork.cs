using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Repositories.Livestock;
using Core.Repositories.Locations;
using Core.Repositories.People;
using Core.Repositories.Taxonomy;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Livestock
        ILivestockRepository Livestock { get; }
        #endregion

        #region Taxonomy
        ISpecieRepository Species { get; }
        IBreedRepository Breeds { get; }
        #endregion

        #region Locations
        IRanchRepository Ranches { get; }
        IRancherRepository Ranchers { get; }
        ICorralRepository Corrals { get; }
        #endregion

        int Complete();
        Task CompleteAsync();
    }
}