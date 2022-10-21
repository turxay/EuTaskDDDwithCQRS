using Application.Common.Mappings;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands.CreateOrder
{
    public class CreateProductCommand : IRequest<int>, IMapTo<Domain.Entities.Product>
    {
        public ProductTypes Name { get; set; }

        public int Count { get; set; }

        public ProductState State { get; set; }

        public int? AssignedPersonId { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<CreateProductCommand, Domain.Entities.Product>()
                .ForMember(d => d.AssignedClientId, o => o.Ignore());
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IRepository<Domain.Entities.Product, int> _productRepository;
        private readonly IRepository<Client, int> _clientRepository;
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IRepository<Domain.Entities.Product, int> productRepository, IRepository<Client, int> clientRepository, IProductManager productManager, IMapper mapper)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _productManager = productManager;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var prod = _mapper.Map<Domain.Entities.Product>(request);

            if (request.AssignedPersonId != null)
            {
                var client = await _clientRepository.GetFirst(request.AssignedPersonId.Value);
                await _productManager.AssignProductToClient(prod, client);
            }

            await _productRepository.Add(prod);

            await _productRepository.Commit(cancellationToken);

            return prod.Id;
        }
    }
}

