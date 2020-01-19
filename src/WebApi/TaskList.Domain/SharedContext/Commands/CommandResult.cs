
namespace TaskList.Domain.SharedContext.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string data, string[] errors = null)
        {
            Success = success;
            Data = data;
            Errors = errors;
        }

        public bool Success { get; }

        public object Data { get; }

        public string[] Errors { get;  }
    }
}
