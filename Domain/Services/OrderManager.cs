using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrderManager : IOrderManager
    {
        public const int MaxActiveOrderCountForAclient = 20;

        private readonly IRepository<OrderToDo, int> _productRepository;

        public OrderManager(IRepository<OrderToDo, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AssignClientToOrder(Client client, OrderToDo order)
        {
            if (order.ClientId == client.Id)
            {
                return;
            }

            if (order.State != OrderState.Active)
            {
                throw new ApplicationException("Can not order a product  when Order is passive!");
            }

            order.ClientId = client.Id;
        }
    }
}
