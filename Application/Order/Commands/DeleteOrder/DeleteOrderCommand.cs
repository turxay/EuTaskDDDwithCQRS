using Application.Common.Exceptions;
using Application.Product.Commands.DeleteOrder;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IRepository<OrderToDo, int> _orderRepository;

        public DeleteProductCommandHandler(IRepository<OrderToDo, int> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _orderRepository.GetFirst(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderToDo), request.Id);
            }

            await _orderRepository.Delete(entity);

            await _orderRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
