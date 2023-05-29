using bmb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Configuration
{
    internal class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Orders> builder)
        {
            builder.Property(x => x.customerId)
                .IsRequired();
            builder.Property(x => x.itemName)
            .IsRequired(); 
            builder.Property(x => x.quantity)
         .IsRequired();
            builder.HasKey(x=> x.id);


         

        }
    }
}
