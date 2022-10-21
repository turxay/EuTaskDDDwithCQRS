using Domain.Common.Exceptions;
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
    public class ProductManager:IProductManager
    {

        private readonly IRepository<Product, int> _productRepository;

        public ProductManager(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AssignProductToClient(Product Product, Client client)
        {
            if (Product.AssignedClientId == client.Id)
            {
                return;
            }

            if (Product.State != ProductState.InService)
            {
                throw new ApplicationException("Can not order a product  when product is not in service!");
            }

            Product.AssignedClientId = client.Id;
        }
    }
}
