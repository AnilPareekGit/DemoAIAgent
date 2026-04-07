using Microsoft.EntityFrameworkCore;
using SupplierManagement.Domain.Entities;

namespace SupplierManagement.Infrastructure.Data;

public class SupplierDbContext : DbContext
{
    public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
    {
    }

    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data
        modelBuilder.Entity<Supplier>().HasData(
            new Supplier
            {
                Id = 1,
                Name = "Acme Corporation",
                Type = "Manufacturer",
                Email = "contact@acme.com",
                Phone = "+1-555-0100",
                Status = "Active"
            },
            new Supplier
            {
                Id = 2,
                Name = "Tech Solutions Inc",
                Type = "Distributor",
                Email = "info@techsolutions.com",
                Phone = "+1-555-0200",
                Status = "Active"
            },
            new Supplier
            {
                Id = 3,
                Name = "Global Supplies Ltd",
                Type = "Wholesaler",
                Email = "support@globalsupplies.com",
                Phone = "+1-555-0300",
                Status = "Inactive"
            }
        );
    }
}
