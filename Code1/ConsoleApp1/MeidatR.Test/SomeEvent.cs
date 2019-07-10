using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeidatR.Test
{
    public class SomeEvent : INotification
    {
        public string Message { get; set; }
        public SomeEvent(string message)
        {
            Message = message;
        }
    }

    public class Handler1 : INotificationHandler<SomeEvent>
    {
        public Task Handle(SomeEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Message);
            return Task.FromCanceled(cancellationToken);
        }
    }
}
