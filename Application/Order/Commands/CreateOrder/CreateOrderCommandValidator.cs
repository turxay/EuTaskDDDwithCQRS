using Domain.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.CreateOrder
{
    internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IRepository<OrderToDo, int> _orderRepository;

        public CreateOrderCommandValidator(IRepository<OrderToDo, int> orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(v => v.Count)
                .NotEmpty().WithMessage("Count is required.");
        }
    }
}
