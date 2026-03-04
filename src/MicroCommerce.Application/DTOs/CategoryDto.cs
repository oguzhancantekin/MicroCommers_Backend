namespace MicroCommerce.Application.DTOs;

/// <summary>
/// Data Transfer Object for Category responses.
/// </summary>
public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
}
