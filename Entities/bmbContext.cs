using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Entities
{
    public class bmbContext : DbContext
    {
        public bmbContext(DbContextOptions<bmbContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Orders> orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.customerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
