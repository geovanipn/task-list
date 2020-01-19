using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskList.Domain.BoardContext.Commands;
using TaskList.Domain.BoardContext.Interfaces.Repositories;
using TaskList.Domain.IdentityContext.Interfaces.Identity;
using TaskList.Domain.SharedContext.CommandHandler;
using Utils.Domain.Interfaces;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Domain.BoardContext.CommandHandlers
{
    public sealed class CreateTaskCommandHandler : 
        CommandHandler, 
        IRequestHandler<CreateTaskCommand>
    {
        private readonly ITaskListIdentity _identity;
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(
            IMediatorService mediatorService, 
            IDbContext dbContext,
            ITaskListIdentity identity,
            ITaskRepository taskRepository) : base(mediatorService, dbContext)
        {
            _identity = identity;
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {   
            if (!await CommandIsValid(request)) return await Unit.Task;

            var task = Models.Task.Create(
                _identity.IdUser,
                request.Title,
                request.Description,
                request.Status,
                request.Id);

            await _taskRepository.Add(task);
            await Commit();

            return await Unit.Task;
        }

        public override void Dispose()
        {
            _taskRepository.Dispose();
            base.Dispose();
        }
    }
}
