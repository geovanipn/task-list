using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using TaskList.Api.Controllers;
using TaskList.Application.IdentityContext.InputModels;
using TaskList.Application.IdentityContext.Interfaces;
using TaskList.Domain.SharedContext.Notifications;
using TaskList.Domain.SharedContext.OutputModels;
using Utils.Domain.Interfaces;

namespace TaskList.Areas.IdentityContext
{
    public sealed class LoginController : ApiController
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(
            IMediatorService mediatorService,
            ILoginAppService loginAppService) : base(mediatorService)
        {
            _loginAppService = loginAppService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("autenticar")]
        [ProducesResponseType(typeof(OkApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateUserInputModel authenticateUserInputModel)
        {
            var authorization = await _loginAppService.Authenticate(authenticateUserInputModel);
            return Response(authorization);
        }
    }
}
