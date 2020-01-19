
namespace TaskList.Domain.IdentityContext.Interfaces.Identity
{
    public interface ITaskListIdentity
    {
        long IdUser { get; }

        bool HasAuthenticatedUser { get; }
    }
}
