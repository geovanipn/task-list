using Microsoft.AspNetCore.Http;
using TaskList.Domain.IdentityContext.Interfaces.Identity;

namespace TaskList.Infra.CrossCutting.Identity
{
    public sealed class TaskListIdentity : Utils.Identity.Identity, ITaskListIdentity
    {
        public TaskListIdentity(IHttpContextAccessor httpContextAccessor) 
            : base(httpContextAccessor)
        { }

        public long IdUser => GetAddtionInformationToInt64("IdUser");
    }
}
