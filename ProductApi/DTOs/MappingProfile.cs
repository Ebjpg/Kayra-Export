using AutoMapper;
using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
    }
}
