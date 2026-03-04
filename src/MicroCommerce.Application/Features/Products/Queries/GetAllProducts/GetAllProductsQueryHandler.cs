using AutoMapper;
using MediatR;
using MicroCommerce.Application.Common.Interfaces;
using MicroCommerce.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MicroCommerce.Application.Features.Products.Queries.GetAllProducts;

/// <summary>
/// Handler for GetAllProductsQuery.
/// Uses IApplicationDbContext directly for read operations with eager loading.
/// </summary>
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }
}
