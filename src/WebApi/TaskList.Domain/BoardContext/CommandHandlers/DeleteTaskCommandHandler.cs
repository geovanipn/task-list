using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskList.Domain.BoardContext.Commands;
using TaskList.Domain.BoardContext.Interfaces.Repositories;
using TaskList.Domain.SharedContext.CommandHandler;
using Utils.Domain.Interfaces;
using Utils.EntityFramework.SqlDataContext;

namespace TaskList.Domain.BoardContext.CommandHandlers
{
    public sealed class DeleteTaskCommandHandler : CommandHandler, IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(
            IMediatorService mediatorService,
            IDbContext dbContext,
            ITaskRepository taskRepository) : base(mediatorService, dbContext)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            if (!await CommandIsValid(request)) return await Unit.Task;

            await _taskRepository.Remove(request.Id);
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
