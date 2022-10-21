using Application.Order.Commands.CreateOrder;
using Application.Order.Commands.DeleteOrder;
using Application.Order.Commands.UpdateOrder;
using Application.Order.Queries.GetOrders;
using Domain.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<OrdersVm>> Get([FromQuery] GetOrdersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderVm>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteOrderCommand { Id = id });

            return NoContent();
        }
    }
}
