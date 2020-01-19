
namespace TaskList.Application.IdentityContext.InputModels
{
    public sealed class AuthenticateUserInputModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
