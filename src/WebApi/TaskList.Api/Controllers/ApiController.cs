using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskList.Domain.SharedContext.Notifications;
using TaskList.Domain.SharedContext.OutputModels;
using Utils.Domain.Interfaces;

namespace TaskList.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly IMediatorService _mediatorService;

        protected ApiController(IMediatorService mediatorService) 
        {
            _mediatorService = mediatorService;
        }

        protected new IActionResult Response(object dataResult = null)
        {
            if (HasNotifications())
                return Ok(new OkApiResponse(dataResult));

            var notifications = _mediatorService.GetNotifications().OfType<DomainNotification>();
            return BadRequest(new ErrorApiResponse(notifications.Select(x => x.Message).ToArray()));
        }

        protected bool HasNotifications() => !_mediatorService.HasNotifications();
    }
}
