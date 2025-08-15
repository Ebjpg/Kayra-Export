using ProductApi.DTOs;

namespace ProductApi.Services;

public interface IProductService
{
    Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken ct = default);
    Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}
