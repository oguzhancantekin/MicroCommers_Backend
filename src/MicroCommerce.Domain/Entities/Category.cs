using MicroCommerce.Domain.Common;

namespace MicroCommerce.Domain.Entities;

/// <summary>
/// Represents a product category in the e-commerce system.
/// Supports hierarchical categories through ParentCategoryId.
/// </summary>
public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    /// <summary>
    /// Optional parent category for hierarchical category support.
    /// </summary>
    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }

    // Navigation properties
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
