using Application.Common.Exceptions;
using Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands.DeleteOrder
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Domain.Entities.Product, int> _productRepository;

        public DeleteProductCommandHandler(IRepository<Domain.Entities.Product, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetFirst(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);
            }

            await _productRepository.Delete(entity);

            await _productRepository.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
