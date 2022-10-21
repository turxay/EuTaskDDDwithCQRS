using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetOrders
{
    public class OrdersVm
    {
        public IList<EnumValueDto> TaskPriorities { get; } =
           Enum.GetValues(typeof(OrderPriority))
               .Cast<OrderPriority>()
               .Select(p => new EnumValueDto { Value = (int)p, Name = p.ToString() })
               .ToList();

        public IList<EnumValueDto> TaskStates =
            Enum.GetValues(typeof(OrderState))
                .Cast<OrderState>()
                .Select(p => new EnumValueDto { Value = (int)p, Name = p.ToString() })
                .ToList();

        public IList<OrderDto> Orders { get; set; }
    }
}
