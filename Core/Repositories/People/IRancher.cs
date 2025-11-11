using Core.Domain.People;
using System.Threading.Tasks;

namespace Core.Repositories.People
{
    public interface IRancherRepository : IRepository<Rancher>
    {
        Rancher GetRancherByUsername(string username);
        Task<Rancher> GetRancherByUsernameAsync(string username);
    }
}