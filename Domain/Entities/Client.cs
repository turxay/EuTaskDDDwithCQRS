using Domain.Common.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public short Age { get; set; }

        public Address Address { get; set; }

        public ICollection<Product> Products { get; set; }
        public OrderToDo Order { get; set; }
    }
}
