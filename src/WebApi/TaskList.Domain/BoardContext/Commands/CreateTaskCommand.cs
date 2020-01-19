using MediatR;
using TaskList.Domain.BoardContext.Validators;

namespace TaskList.Domain.BoardContext.Commands
{
    public sealed class CreateTaskCommand : TaskCommand, IRequest
    {
        private CreateTaskCommand() { }

        public static CreateTaskCommand Create(in string title, in string description) =>
            new CreateTaskCommand
            {
                Title = title,
                Description = description,
                Status = Models.TypeTaskStatus.Active
            };

        public override bool IsValid()
        {
            ValidationResult = new CreateTaskValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
