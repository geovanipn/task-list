using System.Collections.Generic;
using TaskList.Domain.BoardContext.Models;
using TaskList.Domain.BoardContext.OutputModels;
using Utils.Domain.Interface;

namespace TaskList.Domain.BoardContext.Interfaces.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        System.Threading.Tasks.Task<ICollection<TaskOutputModel>> TasksByUser(long userId);
    }
}
