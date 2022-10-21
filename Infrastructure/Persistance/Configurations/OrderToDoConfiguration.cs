using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations
{
    public class OrderToDoConfiguration : IEntityTypeConfiguration<OrderToDo>
    {
        public void Configure(EntityTypeBuilder<OrderToDo> builder)
        {
            builder.ToTable("Orders");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
