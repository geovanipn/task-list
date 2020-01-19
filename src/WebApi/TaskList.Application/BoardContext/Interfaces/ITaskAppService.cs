using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskList.Application.BoardContext.InputModels;
using TaskList.Domain.BoardContext.OutputModels;

namespace TaskList.Application.BoardContext.Interfaces
{
    public interface ITaskAppService
    {
        Task<Unit> Create(CreateTaskInputModel createTaskInputModel);

        Task<Unit> Update(long id, UpdateTaskInputModel updateTaskInputModel);

        Task<Unit> Delete(DeleteTaskInputModel deleteTaskInputModel);

        Task<ICollection<TaskOutputModel>> Tasks(long userId);
    }
}
