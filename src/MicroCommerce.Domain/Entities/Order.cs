using MicroCommerce.Domain.Common;
using MicroCommerce.Domain.Enums;

namespace MicroCommerce.Domain.Entities;

/// <summary>
/// Represents a customer order containing one or more order items.
/// </summary>
public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string? ShippingAddress { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    /// <summary>
    /// Recalculates the total amount based on the order items.
    /// </summary>
    public void CalculateTotalAmount()
    {
        TotalAmount = OrderItems.Sum(item => item.TotalPrice);
    }
}
