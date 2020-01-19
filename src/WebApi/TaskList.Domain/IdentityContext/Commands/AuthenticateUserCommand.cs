using MediatR;
using TaskList.Domain.IdentityContext.Validators;
using Utils.Authentication;

namespace TaskList.Domain.IdentityContext.Commands
{
    public sealed class AuthenticateUserCommand : 
        UserCommand, 
        IRequest<Authorization>
    {
        private AuthenticateUserCommand() { }

        public static AuthenticateUserCommand Create(
            in string userName,
            in string password) =>
            new AuthenticateUserCommand
            {
                UserName = userName,
                Password = password
            };

        public override bool IsValid()
        {
            ValidationResult = new AuthenticateUserValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
