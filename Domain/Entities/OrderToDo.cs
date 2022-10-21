using Domain.Common.Entities;
using Domain.Enums;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderToDo : BaseEntity<int>, ICreationAudited, IModificationAudited, IDeletionAudited, ISoftDelete
    {
        public string Name { get; set; }

        public bool IsCompleted { get; private set; }

        public OrderPriority Priority { get; set; } = OrderPriority.Medium;

        public OrderState State { get; set; } = OrderState.Active;


        public DateTime CreatedDate { get; set; }

        public long? CreatedUserId { get; set; }


        public DateTime? LastModifiedDate { get; set; }

        public long? LastModifiedUserId { get; set; }


        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? DeletedUserId { get; set; }

        public void MarkComplete()
        {
            IsCompleted = true;
            Events.Add(new OrderCompletedEvent(this));
        }

        public void MarkUnComplete()
        {
            IsCompleted = false;
        }

        //navigation properties
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
