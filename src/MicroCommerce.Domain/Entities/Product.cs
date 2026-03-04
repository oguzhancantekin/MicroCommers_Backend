using MicroCommerce.Domain.Common;

namespace MicroCommerce.Domain.Entities;

/// <summary>
/// Represents a product in the e-commerce catalog.
/// </summary>
public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public string SKU { get; set; } = string.Empty;

    // Category relationship
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // Navigation properties
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
