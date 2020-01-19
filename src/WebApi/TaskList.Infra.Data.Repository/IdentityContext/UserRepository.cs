using System.Linq;
using System.Threading.Tasks;
using TaskList.Domain.IdentityContext.Interfaces.Repositories;
using TaskList.Domain.IdentityContext.Models;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Infra.Data.Repository.IdentityContext
{
    public sealed class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext context) 
            : base(context)
        { }

        public async Task<User> GetByName(string name)
        {
            return await Task.Run(() => 
                DbSet.FirstOrDefault(user => user.Name == name));
        }
    }
}
