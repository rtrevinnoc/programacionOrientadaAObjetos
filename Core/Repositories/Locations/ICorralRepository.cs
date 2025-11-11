using Core.Domain.Locations;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace Core.Repositories.Locations
{
    public interface ICorralRepository : IRepository<Corral>
    {
        Task<IEnumerable<Corral>> GetAllWithRanchAsync();
        Task<Corral> GetByIdWithRanchAsync(Guid id);
    }
}