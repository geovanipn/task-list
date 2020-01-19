using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utils.Domain.Interface;
using Utils.Domain.Models;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Infra.Data.Repository
{
    public abstract class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected EntityFrameworkRepository(IDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity) => await DbSet.AddAsync(entity);

        public virtual async Task Update(TEntity entity)
        {
            await Task.Run(() =>
            {
                var localEntity = DbSet.Local.FirstOrDefault(x => x.Id.Equals(entity.Id));

                var entry = Context.Entry(localEntity ?? entity);
                if (localEntity == null) DbSet.Attach(entity);
                else entry.CurrentValues.SetValues(entity);

                entry.State = EntityState.Modified;
            });
        }

        public virtual async Task Remove(long id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null) return;

            await Task.Run(() => DbSet.Remove(entity));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(in bool disposing)
        {
            if (!disposing) return;

            Context?.Dispose();
        }
    }
}
