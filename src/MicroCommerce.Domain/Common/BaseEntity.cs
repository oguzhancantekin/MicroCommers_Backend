namespace MicroCommerce.Domain.Common;

/// <summary>
/// Base entity class that all domain entities inherit from.
/// Provides common audit fields for tracking creation and modification.
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
