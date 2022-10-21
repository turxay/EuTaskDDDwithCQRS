using Domain.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Entities
{
    public class BaseEntity<T> : HaveDomainEvents, IEntity
    {
        public T? Id { get; set; }
    }
}
