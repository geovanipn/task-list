using System;
using System.Threading.Tasks;

namespace Utils.Domain.Interface
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(long id);
    }
}
