using MicroCommerce.Domain.Common;

namespace MicroCommerce.Domain.Entities;

/// <summary>
/// Represents an individual line item within an order.
/// Stores the price at the time of purchase to preserve order history.
/// </summary>
public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    /// <summary>
    /// Unit price at the time of purchase (snapshot, not live).
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Total price for this line item (Quantity x UnitPrice).
    /// </summary>
    public decimal TotalPrice => Quantity * UnitPrice;
}
