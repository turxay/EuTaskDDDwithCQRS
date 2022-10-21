using Application.Common.Mappings;
using Application.Product.Queries.GetProducts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderVm>, IMapTo<OrderToDo>
    {
        public string Name { get; set; }

        public ProductTypes product { get; set; }

        public int Count { get; set; }

        public OrderPriority Priority { get; set; }

        public OrderState State { get; set; }

        public int? AssignedClientId { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<CreateOrderCommand, OrderToDo>()
                .ForMember(d => d.ClientId, o => o.Ignore());
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderVm>
    {
        private readonly IRepository<OrderToDo, int> _orderRepository;
        private readonly IRepository<Client, int> _clientRepository;
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Product, int> _productRepository;

        public CreateTaskCommandHandler(IRepository<OrderToDo, int> orderRepository, IRepository<Client, int> clientRepository, 
            IOrderManager orderManager, IMapper mapper, IRepository<Domain.Entities.Product, int> productRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _orderManager = orderManager;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CreateOrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            string message = string.Empty;
            var productCount = _productRepository.GetAll().Where(t => t.Name == request.product)
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider);
            if (productCount.First().Count>=request.Count)
            {
                message = "We have enough product for you, You can approach to warehouse!!";
            }
            else
            {
                message = "We dont have enough in stock, please hold on until you get an email";
            }

            
            var prod = _mapper.Map<OrderToDo>(request);
            if (request.AssignedClientId != null)
            {
                var client = await _clientRepository.GetFirst(request.AssignedClientId.Value);
                await _orderManager.AssignClientToOrder(client, prod);
            }
            await _orderRepository.Add(prod);

            await _orderRepository.Commit(cancellationToken);

            var vm = new CreateOrderVm
            {
                OrderId = prod.Id,
                Message = message

            };

            return vm;
        }

    }
}

//This exception was originally thrown at this call stack:
//    [External Code]
//Application.Order.Commands.CreateOrder.CreateTaskCommandHandler.Handle(Application.Order.Commands.CreateOrder.CreateOrderCommand, System.Threading.CancellationToken) in CreateOrderCommand.cs
//[External Code]
//    Application.Common.Behaviours.RequestValidationBehavior<TRequest, TResponse>.Handle(TRequest, MediatR.RequestHandlerDelegate<TResponse>, System.Threading.CancellationToken) in RequestValidationBehavior.cs
//    [External Code]
//    Application.Common.Behaviours.RequestPerformanceBehaviour<TRequest, TResponse>.Handle(TRequest, MediatR.RequestHandlerDelegate<TResponse>, System.Threading.CancellationToken) in RequestPerformanceBehaviour.cs
//    [External Code]
//    Presentation.Controllers.OrderController.Create(Application.Order.Commands.CreateOrder.CreateOrderCommand) in OrderController.cs
//    [External Code]
//    Presentation.Common.CustomExceptionHandlerMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext) in CustomExceptionHandlerMiddleware.cs
