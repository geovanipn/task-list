using TaskList.Domain.BoardContext.Commands;

namespace TaskList.Domain.BoardContext.Validators
{
    public sealed class UpdateTaskValidator : TaskValidator<UpdateTaskCommand>
    {
        public UpdateTaskValidator()
        {
            ValidateId();
            ValidateTitle();
            ValidateTaskStatus();
        }
    }
}
