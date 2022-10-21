using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class OrderCompletedEmailNotificationHandler : INotificationHandler<OrderCompletedEvent>
    {
        public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            // Do Nothing
            return Task.CompletedTask;
        }
    }
}
