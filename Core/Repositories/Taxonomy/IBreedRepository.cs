using Core.Domain.Taxonomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Taxonomy
{
    public interface IBreedRepository : IRepository<Breed>
    {
        Task<IEnumerable<Breed>> GetAllWithSpecieAsync();
        Task<Breed> GetByIdWithSpecieAsync(Guid id);
    }
}
