using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Models;
using Microsoft.EntityFrameworkCore;

namespace distrito7.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers {get; set;} = null!;
        public DbSet<CustomerAM> CustomerAM { get; set; } = null!;
        public DbSet<CustomerPayment> CustomerPayments { get; set; } = null!;
        public DbSet<CustomerProgress> CustomerProgresses { get; set; } = null!;
        public DbSet<PaymentPlan> PaymentPlans { get; set; } = null!;
        public DbSet<AnthropometricMeasurements> AnthropometricMeasurements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(t => t.Email)
                .IsUnique();
        }
    }
}