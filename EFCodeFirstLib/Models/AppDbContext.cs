using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstLib.Models
{
    public class AppDbContext : DbContext
    {
        // DbSets go here
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        // Fluent API expression here
        protected override void OnModelCreating(ModelBuilder builder) // Uses model builder object to implement fluent api
        {
            builder.Entity<Customer>(e => {
                e.HasIndex(p => p.Code).IsUnique(true);
                e.Property(p => p.Name)
                    .HasMaxLength(30)
                    .IsRequired(true);
            });
        }

        public AppDbContext() {}

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                var connStr = 
                    "server=localhost\\sqlexpress;database=EfCodeFirstDb;trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }

        }
    }
}
