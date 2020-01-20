using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Domain.BoardContext.Interfaces.Repositories;
using TaskList.Domain.BoardContext.Models;
using TaskList.Domain.BoardContext.OutputModels;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Infra.Data.Repository.BoardContext
{
    public sealed class TaskRepository : EntityFrameworkRepository<Domain.BoardContext.Models.Task>, ITaskRepository
    {
        public TaskRepository(IDbContext context) 
            : base(context)
        { }

        public override async System.Threading.Tasks.Task Remove(long id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null) return;

            Context.Entry(entity)
                .Property(x => x.Status)
                .CurrentValue = TypeTaskStatus.Removed;
        }

        public async Task<ICollection<TaskOutputModel>> TasksByUser(long userId)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                return DbSet.Where(x => x.IdUser == userId && x.Status != TypeTaskStatus.Removed).Select(task =>
                   new TaskOutputModel(
                       task.Id,
                       task.Title,
                       task.Description,
                       task.Status)).ToList();
            });
        }
    }
}
