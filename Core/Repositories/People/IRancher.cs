using Core.Domain.People;

namespace Core.Repositories.People
{
    public interface IRancherRepository : IRepository<Rancher>
    {
        Rancher GetRancherByUsername(string username);
    }
}