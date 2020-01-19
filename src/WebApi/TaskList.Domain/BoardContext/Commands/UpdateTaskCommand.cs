using MediatR;
using TaskList.Domain.BoardContext.Models;
using TaskList.Domain.BoardContext.Validators;

namespace TaskList.Domain.BoardContext.Commands
{
    public sealed class UpdateTaskCommand : TaskCommand, IRequest
    {
        private UpdateTaskCommand() { }

        public static UpdateTaskCommand Create(
            in long idTask,
            in string title,
            in string description,
            in TypeTaskStatus status) =>
            new UpdateTaskCommand
            {
                Id = idTask,
                Title = title,
                Description = description,
                Status = status
            };

        public override bool IsValid()
        {
            ValidationResult = new UpdateTaskValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
