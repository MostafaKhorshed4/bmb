using bmb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.name)
                .IsRequired();
            builder.Property(x => x.password)
            .IsRequired();
            builder.HasKey(x=> x.id);


         

        }
    }
}
