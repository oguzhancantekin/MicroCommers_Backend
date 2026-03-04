using MediatR;
using MicroCommerce.Application.DTOs;

namespace MicroCommerce.Application.Features.Products.Queries.GetAllProducts;

/// <summary>
/// Query for retrieving all products.
/// Implements CQRS pattern - this is the "read" side.
/// </summary>
public class GetAllProductsQuery : IRequest<IReadOnlyList<ProductDto>>
{
}
