using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Domain.Interfaces;

namespace Utils.Mediator
{
    public sealed class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        private readonly IList<INotification> _notifications;

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
            _notifications = new List<INotification>();
        }

        public IList<INotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications() => _notifications.Any();

        public async Task<T> SendCommand<T>(IRequest<T> command)
        {
            return await _mediator.Send(command as IRequest<T>);
        }

        public async Task SendNotification(INotification @notification)
        {
            await Task.Run(() => _notifications.Add(notification));
        }
    }
}
