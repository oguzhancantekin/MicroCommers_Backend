using AutoMapper;
using MicroCommerce.Application.DTOs;
using MicroCommerce.Domain.Entities;

namespace MicroCommerce.Application.Common.Mappings;

/// <summary>
/// AutoMapper profile that defines mappings between domain entities and DTOs.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product mappings
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        // Category mappings
        CreateMap<Category, CategoryDto>();

        // Order mappings
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
    }
}
