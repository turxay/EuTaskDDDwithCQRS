using Domain.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands.CreateOrder
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IRepository<Domain.Entities.Product, int> _productRepository;

        public CreateProductCommandValidator(IRepository<Domain.Entities.Product, int> orderRepository)
        {
            _productRepository = orderRepository;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(v => v.Count)
                .NotEmpty().WithMessage("Count is required.");
        }
    }
}
