using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ProductsVm>
    {
        public byte Name { get; set; }
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetProductsQuery, ProductsVm>
    {
        private readonly IRepository<Domain.Entities.Product, int> _productRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IMapper mapper, IRepository<Domain.Entities.Product, int> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductsVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var vm = new ProductsVm
            {
                Product = _productRepository.GetAll().Where(t => (byte)t.Name == request.Name)
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).First()
            };

            return vm;
        }
    }
}
