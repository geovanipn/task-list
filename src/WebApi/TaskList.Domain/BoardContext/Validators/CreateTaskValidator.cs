using TaskList.Domain.BoardContext.Commands;

namespace TaskList.Domain.BoardContext.Validators
{
    public sealed class CreateTaskValidator : TaskValidator<CreateTaskCommand>
    {
        public CreateTaskValidator()
        {
            ValidateTitle();
        }
    }
}
