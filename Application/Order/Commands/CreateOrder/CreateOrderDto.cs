using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.CreateOrder
{
    public class CreateOrderDto : IMapFrom<OrderToDo>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public OrderPriority Priority { get; set; }

        public OrderState State { get; set; }
    }
}
