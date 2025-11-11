using System.Linq;
using Core.Domain.People;
using Core.Repositories.People;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; 

namespace Persistence.Persistence.Repositories.People
{
    public class RancherRepository : Repository<Rancher>, IRancherRepository
    {

        public RancherRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
        }

        public Rancher GetRancherByUsername(string username)
        {
            return Context.Ranchers.SingleOrDefault(r => r.Username == username);
        }

        public async Task<Rancher> GetRancherByUsernameAsync(string username)
        {
            return await Context.Ranchers
                .SingleOrDefaultAsync(r => r.Username == username);
        }
    }
}