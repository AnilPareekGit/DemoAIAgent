using SupplierManagement.Domain.Entities;

namespace SupplierManagement.Domain.Repositories;

public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(int id);
    Task<IEnumerable<Supplier>> GetAllAsync();
    Task<Supplier> CreateAsync(Supplier supplier);
}
