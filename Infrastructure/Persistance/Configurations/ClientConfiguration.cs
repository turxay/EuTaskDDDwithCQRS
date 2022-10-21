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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.Property(t => t.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(t => t.Order).WithOne(p => p.Client)
            .HasForeignKey<OrderToDo>(t => t.ClientId);

            builder.OwnsOne(o => o.Address);
        }
    }
}
