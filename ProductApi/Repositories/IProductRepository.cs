using ProductApi.Models;

namespace ProductApi.Repositories;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product, CancellationToken ct = default);
    Task<List<Product>> GetAllAsync(CancellationToken ct = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task DeleteAsync(Product product, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
