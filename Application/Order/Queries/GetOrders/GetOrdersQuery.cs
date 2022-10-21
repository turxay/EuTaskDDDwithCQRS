using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<OrdersVm>
    {
        public string Name { get; set; }
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OrdersVm>
    {
        private readonly IRepository<OrderToDo, int> _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IMapper mapper, IRepository<OrderToDo, int> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<OrdersVm> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var vm = new OrdersVm
            {
                Orders = await _orderRepository.GetAll().Where(t => t.Name.Contains(request.Name))
                    .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
