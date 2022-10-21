using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Queries.GetProducts
{
    public class ProductsVm
    {
        public IList<EnumValueDto> ProductTypes =
            Enum.GetValues(typeof(ProductTypes))
                .Cast<ProductTypes>()
                .Select(p => new EnumValueDto { Value = (int)p, Name = p.ToString() })
                .ToList();

        public IList<EnumValueDto> ProductStates =
            Enum.GetValues(typeof(OrderState))
                .Cast<OrderState>()
                .Select(p => new EnumValueDto { Value = (int)p, Name = p.ToString() })
                .ToList();

        public ProductDto Product { get; set; }


    }
}
