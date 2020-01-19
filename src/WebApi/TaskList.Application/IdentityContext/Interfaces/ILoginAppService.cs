using System.Threading.Tasks;
using TaskList.Application.IdentityContext.InputModels;
using Utils.Authentication;

namespace TaskList.Application.IdentityContext.Interfaces
{
    public interface ILoginAppService
    {
        Task<Authorization> Authenticate(AuthenticateUserInputModel authenticateUserInputModel);
    }
}
