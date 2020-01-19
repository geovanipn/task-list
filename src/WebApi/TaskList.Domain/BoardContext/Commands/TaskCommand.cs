using TaskList.Domain.BoardContext.Models;
using TaskList.Domain.SharedContext.Commands;

namespace TaskList.Domain.BoardContext.Commands
{
    public abstract class TaskCommand : Command
    {
        public long Id { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public TypeTaskStatus Status { get; protected set; }
    }
}
