using System.Threading.Tasks;
using TaskList.Domain.IdentityContext.Models;
using Utils.Domain.Interface;

namespace TaskList.Domain.IdentityContext.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByName(string name);
    }
}
