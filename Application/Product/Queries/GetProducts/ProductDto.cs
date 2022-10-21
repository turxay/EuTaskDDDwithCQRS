using Application.Common.Mappings;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Queries.GetProducts
{
    public class ProductDto : IMapFrom<Domain.Entities.Product>
    {
        public int Id { get; set; }

        public ProductTypes Name { get; set; }

        public int Count { get; set; }

        public ProductState State { get; set; }
    }
}
