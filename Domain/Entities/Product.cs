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
    public class Product : BaseEntity<int>, ICreationAudited, IModificationAudited, IDeletionAudited, ISoftDelete
    {
        public ProductTypes Name { get; set; }

        public int Count { get; set; }

        public bool IsCompleted { get; private set; }

        public ProductState State { get; set; } = ProductState.InService;


        public DateTime CreatedDate { get; set; }

        public long? CreatedUserId { get; set; }


        public DateTime? LastModifiedDate { get; set; }

        public long? LastModifiedUserId { get; set; }


        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? DeletedUserId { get; set; }

        public void MarkUnComplete()
        {
            IsCompleted = false;
        }

        //navigation properties
        public int AssignedClientId { get; set; }
        public Client Client { get; set; }

       
    }
}
