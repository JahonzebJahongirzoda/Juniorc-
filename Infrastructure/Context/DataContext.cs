using System;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //CourseAssignment Many to Many Course/Instructor
        modelBuilder.Entity<CustomerPurchaces>()
        .HasOne(c => c.Customer)
        .WithMany(ca => ca.CustomerPurchaces)
        .HasForeignKey(ci => ci.CustomerId);

        modelBuilder.Entity<CustomerPurchaces>()
        .HasOne(i => i.Installment)
        .WithMany(ca => ca.CustomerPurchaces)
        .HasForeignKey(ii => ii.InstallmentId);

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerPurchaces> CustomerPurchaces { get; set; }
    public DbSet<Installment> Installments { get; set; }
    public DbSet<Product> Products { get; set; }

}