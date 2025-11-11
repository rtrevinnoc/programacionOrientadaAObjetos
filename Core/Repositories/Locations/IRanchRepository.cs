using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Locations;
using Core.Repositories;

namespace Core.Repositories.Locations
{
    public interface IRanchRepository : IRepository<Ranch>
    {
        Task<IEnumerable<Ranch>> GetAllWithRancherAsync();
        Task<Ranch> GetByIdWithRancherAsync(Guid id);
    }
}