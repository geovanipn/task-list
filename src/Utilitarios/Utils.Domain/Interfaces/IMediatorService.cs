using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utils.Domain.Interfaces
{
    public interface IMediatorService
    {
        Task<T> SendCommand<T>(IRequest<T> command);

        Task SendNotification(INotification notification);

        IList<INotification> GetNotifications();

        bool HasNotifications();
    }
}
