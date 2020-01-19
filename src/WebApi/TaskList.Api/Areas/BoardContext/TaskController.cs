using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Api.Controllers;
using TaskList.Application.BoardContext.InputModels;
using TaskList.Application.BoardContext.Interfaces;
using TaskList.Domain.IdentityContext.Interfaces.Identity;
using TaskList.Domain.SharedContext.OutputModels;
using Utils.Domain.Interfaces;

namespace TaskList.Api.Areas.BoardContext
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public sealed class TaskController : ApiController
    {
        private readonly ITaskListIdentity _identity;
        private readonly ITaskAppService _taskAppService;

        public TaskController(
            ITaskListIdentity taskListIdentity,
            ITaskAppService taskAppService, 
            IMediatorService mediatorService) : base(mediatorService)
        {
            _identity = taskListIdentity;
            _taskAppService = taskAppService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("")]
        [ProducesResponseType(typeof(OkApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CreateTaskInputModel inputModel)
        {
            await _taskAppService.Create(inputModel);
            return Response();
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody]UpdateTaskInputModel inputModel)
        {
            await _taskAppService.Update(id, inputModel);
            return Response();
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("{id}")]
        [ProducesResponseType(typeof(OkApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] DeleteTaskInputModel inputModel)
        {
            await _taskAppService.Delete(inputModel);
            return Response();
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("listagem")]
        [ProducesResponseType(typeof(OkApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List()
        {
            var tasks = await _taskAppService.Tasks(_identity.IdUser);
            return Response(tasks);
        }
    }
}
