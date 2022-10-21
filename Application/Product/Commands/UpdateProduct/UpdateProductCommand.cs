using Application.Common.Exceptions;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands.UpdateOrder
{
    public class UpdateProductCommand : IRequest, IMapTo<Domain.Entities.Product>
    {
        public int Id { get; set; }

        public ProductTypes Name { get; set; }

        public bool IsComplete { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Domain.Entities.Product, int> _orderRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Domain.Entities.Product, int> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var task = await _orderRepository.GetFirst(request.Id);

            if (task == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);
            }

            _mapper.Map(request, task);



            await _orderRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
