
namespace TaskList.Domain.SharedContext.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }

        object Data { get; }

        string[] Errors { get; }
    }
}
