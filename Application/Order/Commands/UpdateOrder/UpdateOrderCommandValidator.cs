using Domain.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.UpdateOrder
{
    internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        private readonly IRepository<OrderToDo, int> _orderListRepository;

        public UpdateOrderCommandValidator(IRepository<OrderToDo, int> orderListRepository)
        {
            _orderListRepository = orderListRepository;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }
}
