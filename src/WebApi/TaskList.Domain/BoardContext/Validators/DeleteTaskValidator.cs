using TaskList.Domain.BoardContext.Commands;

namespace TaskList.Domain.BoardContext.Validators
{
    public sealed class DeleteTaskValidator : TaskValidator<DeleteTaskCommand>
    {
        public DeleteTaskValidator()
        {
            ValidateId();
        }
    }
}
