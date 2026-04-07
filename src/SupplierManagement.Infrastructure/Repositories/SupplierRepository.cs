using Microsoft.EntityFrameworkCore;
using SupplierManagement.Domain.Entities;
using SupplierManagement.Domain.Repositories;
using SupplierManagement.Infrastructure.Data;

namespace SupplierManagement.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly SupplierDbContext _context;

    public SupplierRepository(SupplierDbContext context)
    {
        _context = context;
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        return await _context.Suppliers.FindAsync(id);
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task<Supplier> CreateAsync(Supplier supplier)
    {
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }
}
