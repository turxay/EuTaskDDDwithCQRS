using Application.Common.Exceptions;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest, IMapTo<OrderToDo>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<OrderToDo, int> _orderRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<OrderToDo, int> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var task = await _orderRepository.GetFirst(request.Id);

            if (task == null)
            {
                throw new NotFoundException(nameof(OrderToDo), request.Id);
            }

            _mapper.Map(request, task);



            await _orderRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}

