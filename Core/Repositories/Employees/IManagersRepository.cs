using Core.Domain.Employees;

namespace Core.Repositories.Employees;
public interface IManagersRepository : IRepository<Manager>
{
    public Manager GetManagerByUsername(string username);
}
