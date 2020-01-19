using TaskList.Domain.SharedContext.Commands;

namespace TaskList.Domain.IdentityContext.Commands
{
    public abstract class UserCommand : Command
    {
        public string UserName { get; protected set; }

        public string Password { get; protected set; }
    }
}
