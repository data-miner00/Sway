namespace Sway.Core.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public OrderStatus Status { get; set; }

    public double TotalAmount { get; set; }

    public string Currency { get; set; }

    public string PaymentInfoId { get; set; }

    public Guid ShippingAddressId { get; set; }

    public Guid BillingAddressId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
