using AutoMapper;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class ProductService(IProductRepository repo, IMapper mapper) : IProductService
{
    public async Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken ct = default)
    {
        var entity = mapper.Map<Product>(dto);
        await repo.AddAsync(entity, ct);
        await repo.SaveChangesAsync(ct);
        return mapper.Map<ProductDto>(entity);
    }

    public async Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await repo.GetAllAsync(ct);
        return list.Select(x => new ProductDto {
            Id = x.Id, Name = x.Name, Description = x.Description,
            Price = x.Price, Stock = x.Stock, CreatedAt = x.CreatedAt
        }).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var p = await repo.GetByIdAsync(id, ct);
        return p is null ? null : new ProductDto {
            Id = p.Id, Name = p.Name, Description = p.Description,
            Price = p.Price, Stock = p.Stock, CreatedAt = p.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var existing = await repo.GetByIdAsync(id, ct);
        if (existing is null) return false;
        await repo.DeleteAsync(existing, ct);
        await repo.SaveChangesAsync(ct);
        return true;
    }
}
