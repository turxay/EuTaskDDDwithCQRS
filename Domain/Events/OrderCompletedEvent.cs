using Domain.Common.DomainEvents;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class OrderCompletedEvent : BaseDomainEvent
    {
        public OrderToDo CompletedOrder { get; set; }

        public OrderCompletedEvent(OrderToDo completedOrder)
        {
            CompletedOrder = completedOrder;
        }
    }
}
