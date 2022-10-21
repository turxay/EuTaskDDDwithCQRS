using Domain.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands.UpdateOrder
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IRepository<Domain.Entities.Product, int> _orderListRepository;

        public UpdateProductCommandValidator(IRepository<Domain.Entities.Product, int> orderListRepository)
        {
            _orderListRepository = orderListRepository;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }
}
