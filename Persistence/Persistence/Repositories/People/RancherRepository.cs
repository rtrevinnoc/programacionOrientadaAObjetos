using System.Linq;
using Core.Domain.People;
using Core.Repositories.People;


namespace Persistence.Persistence.Repositories.People
{
    public class RancherRepository : Repository<Rancher>, IRancherRepository
    {
private readonly ProgramacionOrientadaAObjetosContext _specificContext;

        public RancherRepository(ProgramacionOrientadaAObjetosContext context) : base(context)
        {
            _specificContext = context;
        }

        public Rancher GetRancherByUsername(string username)
        {
            return _specificContext.Ranchers.SingleOrDefault(r => r.Username == username);
        }
    }
}