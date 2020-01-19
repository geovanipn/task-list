using MediatR;
using System;

namespace TaskList.Domain.SharedContext.Notifications
{
    public sealed class DomainNotification : INotification
    {
        public Guid Id { get; }

        public string Key { get; private set; }

        public string Message { get; private set; }

        public DomainNotification(in string key, in string message)
        {
            Id = Guid.NewGuid();
            Key = key;
            Message = message;
        }
    }
}
