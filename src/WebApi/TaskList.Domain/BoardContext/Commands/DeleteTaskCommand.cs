using MediatR;
using TaskList.Domain.BoardContext.Validators;

namespace TaskList.Domain.BoardContext.Commands
{
    public sealed class DeleteTaskCommand : TaskCommand, IRequest
    {
        private DeleteTaskCommand() { }

        public static DeleteTaskCommand Create(in long id) =>
            new DeleteTaskCommand
            {
                Id = id
            };

        public override bool IsValid()
        {
            ValidationResult = new DeleteTaskValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
