using FluentValidation;
using TaskList.Domain.IdentityContext.Commands;

namespace TaskList.Domain.IdentityContext.Validators
{
    public abstract class UserValidator<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateName() =>
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Nome do usuário deve ser informado!");

        protected void ValidatePassword() =>
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha deve ser informada!");
    }
}
