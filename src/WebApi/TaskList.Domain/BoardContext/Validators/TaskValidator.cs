using FluentValidation;
using TaskList.Domain.BoardContext.Commands;

namespace TaskList.Domain.BoardContext.Validators
{
    public abstract class TaskValidator<T> : AbstractValidator<T> where T : TaskCommand
    {
        protected void ValidateId() =>
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id da Task deve ser maior que zero!");

        protected void ValidateTitle() =>
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Título da Task deve ser informado!");

        protected void ValidateTaskStatus() =>
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status da Task deve ser informado!");
    }
}
