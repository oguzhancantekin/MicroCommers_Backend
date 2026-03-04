using MediatR;

namespace MicroCommerce.Application.Features.Products.Commands.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// Implements CQRS pattern - this is the "write" side.
/// </summary>
public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public string SKU { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}
