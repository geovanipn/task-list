using TaskList.Domain.IdentityContext.Commands;

namespace TaskList.Domain.IdentityContext.Validators
{
    public sealed class AuthenticateUserValidator : UserValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserValidator()
        {
            ValidateName();
            ValidatePassword();
        }
    }
}
